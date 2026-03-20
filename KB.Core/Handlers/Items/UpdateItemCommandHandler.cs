using MediatR;
using KB.Core.Models;

namespace KB.Core.Handlers.Items {

  public record UpdateItemCommand(
    int Id,
    int ItemTypeId,
    string Name,
    string Description,
    string Data,
    bool IsActive
  ) : IRequest<ItemDto>;


  public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, ItemDto> {
    private readonly KbDbContext _context;

    public UpdateItemCommandHandler(KbDbContext context) {
      _context = context;
    }

    public async Task<ItemDto> Handle(UpdateItemCommand request, CancellationToken cancellationToken) {

      var item = await _context.Items.FindAsync(request.Id);

      if (item == null) {
        throw new KeyNotFoundException("Item not found");
      }

      item.Name = request.Name;
      item.Description = request.Description;
      item.Data = request.Data;
      item.ItemTypeId = request.ItemTypeId;
      item.IsActive = request.IsActive;

      await _context.SaveChangesAsync(cancellationToken);

      return item.ToDto();
    }
  }
}
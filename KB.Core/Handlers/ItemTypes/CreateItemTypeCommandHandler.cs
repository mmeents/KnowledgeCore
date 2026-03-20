using MediatR;
using KB.Core.Models;

namespace KB.Core.Handlers.ItemTypes {
  public record CreateItemTypeCommand(string Name, string Description) : IRequest<ItemTypeDto>;
  public class CreateItemTypeCommandHandler : IRequestHandler<CreateItemTypeCommand, ItemTypeDto> {
    private readonly KbDbContext _context;

    public CreateItemTypeCommandHandler(KbDbContext context) {
      _context = context;
    }

    public async Task<ItemTypeDto> Handle(CreateItemTypeCommand request, CancellationToken cancellationToken) {
      var itemType = new Entities.ItemType {
        Name = request.Name,
        Description = request.Description
      };

      _context.ItemTypes.Add(itemType);
      await _context.SaveChangesAsync(cancellationToken);

      return itemType.ToDto();
    }
  }
}

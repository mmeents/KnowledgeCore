using MediatR;
using KB.Core.Models;

namespace KB.Core.Handlers.ItemRelationTypes {
    public record CreateItemRelationTypeCommand(string Relation, string Description) : IRequest<ItemRelationTypeDto>;

  public class CreateItemRelationTypeCommandHandler : IRequestHandler<CreateItemRelationTypeCommand, ItemRelationTypeDto> {
    private readonly KbDbContext _context;

    public CreateItemRelationTypeCommandHandler(KbDbContext context) {
      _context = context;
    }

    public async Task<ItemRelationTypeDto> Handle(CreateItemRelationTypeCommand request, CancellationToken cancellationToken) {
      var itemRelationType = new Entities.ItemRelationType {
        Relation = request.Relation,
        Description = request.Description
      };

      _context.ItemRelationTypes.Add(itemRelationType);
      await _context.SaveChangesAsync(cancellationToken);

      return itemRelationType.ToDto();
    }
  }
}
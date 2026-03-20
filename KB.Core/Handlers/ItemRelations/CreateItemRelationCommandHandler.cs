using MediatR;
using KB.Core.Entities;
using KB.Core.Models;

namespace KB.Core.Handlers.ItemRelations {
  public record CreateItemRelationCommand(
      int ItemId,
      int RelationTypeId,
      int RelatedItemId
  ) : IRequest<ItemRelationDto>;

  public class CreateItemRelationCommandHandler : IRequestHandler<CreateItemRelationCommand, ItemRelationDto> {
    private readonly KbDbContext _context;
    public CreateItemRelationCommandHandler(KbDbContext context) {
      _context = context;
    }
    public async Task<ItemRelationDto> Handle(CreateItemRelationCommand request, CancellationToken cancellationToken) {
      var itemRelation = new ItemRelation {
        ItemId = request.ItemId,
        RelationTypeId = request.RelationTypeId,
        RelatedItemId = request.RelatedItemId
      };
      _context.ItemRelations.Add(itemRelation);
      await _context.SaveChangesAsync(cancellationToken);
      return itemRelation.ToDto();

    }
  }
}

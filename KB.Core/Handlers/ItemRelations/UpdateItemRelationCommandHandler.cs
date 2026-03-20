using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using KB.Core.Models;

namespace KB.Core.Handlers.ItemRelations {
  public record UpdateItemRelationCommand(
      int Id,
      int ItemId,
      int RelationTypeId,
      int RelatedItemId
  ) : IRequest<ItemRelationDto>;
  public class UpdateItemRelationCommandHandler : IRequestHandler<UpdateItemRelationCommand, ItemRelationDto> {
    private readonly KbDbContext _context;
    public UpdateItemRelationCommandHandler(KbDbContext context) {
      _context = context;
    }
    public async Task<ItemRelationDto> Handle(UpdateItemRelationCommand request, CancellationToken cancellationToken) {
      var itemRelation = await _context.ItemRelations.FindAsync(request.Id);
      if (itemRelation == null) {
        throw new KeyNotFoundException("Item relation not found");
      }
      itemRelation.ItemId = request.ItemId;
      itemRelation.RelationTypeId = request.RelationTypeId;
      itemRelation.RelatedItemId = request.RelatedItemId;
      await _context.SaveChangesAsync(cancellationToken);
      return itemRelation.ToDto();
    }
  }
}
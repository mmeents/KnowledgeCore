using KB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Core.Models {
  public class ItemRelationDto {
    public int Id { get; set; }
    public int ItemId { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public int RelatedItemId { get; set; }
    public string RelatedItemName { get; set; } = string.Empty;
    public int RelationTypeId { get; set; }
    public string RelationTypeName { get; set; } = string.Empty;
    public DateTime Established { get; set; }
  }

  public static class ItemRelationExtensions {

    public static ItemRelationDto ToDto(this ItemRelation relation) {
      return new ItemRelationDto {
        Id = relation.Id,
        ItemId = relation.ItemId,
        ItemName = relation.Item?.Name ?? string.Empty,
        RelatedItemId = relation.RelatedItemId,
        RelatedItemName = relation.RelatedItem?.Name ?? string.Empty,
        RelationTypeId = relation.RelationTypeId,
        RelationTypeName = relation.RelationType?.Relation ?? string.Empty,
        Established = relation.Established
      };
    }
  }

}

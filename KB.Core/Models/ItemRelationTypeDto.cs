using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Core.Models {
  public class ItemRelationTypeDto {
    public int Id { get; set; }
    public string Relation { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

  }

  public static class ItemRelationTypeExtensions {
    public static ItemRelationTypeDto ToDto(this Entities.ItemRelationType entity) {
      return new ItemRelationTypeDto {
        Id = entity.Id,
        Relation = entity.Relation,
        Description = entity.Description
      };
    }
  }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Core.Models {
  public class ItemTypeDto {
    public int Id { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
  }

  public static class ItemTypeExtensions {
    public static ItemTypeDto ToDto(this Entities.ItemType itemType) {
      return new ItemTypeDto {
        Id = itemType.Id,
        Name = itemType.Name,
        Description = itemType.Description
      };
    }
  }

}

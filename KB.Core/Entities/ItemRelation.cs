using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Core.Entities {

  public class ItemRelation {
    public int Id { get; set; } = 0;
    public int ItemId { get; set; } = 0;
    public int RelationTypeId { get; set; } = 0;
    public int? RelatedItemId { get; set; } = null;
    public DateTime Established { get; set; } = DateTime.UtcNow;


    // Nav properties
    public Item Item { get; set; } = null!;
    public Item? RelatedItem { get; set; } = null!;
    public ItemRelationType RelationType { get; set; } = null!;

    public ItemRelation() { }

  }


}

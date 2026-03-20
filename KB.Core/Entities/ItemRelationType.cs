using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Core.Entities {
  public class ItemRelationType {
    public int Id { get; set; } = 0;
    public string Relation { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Nav properties
    public ICollection<ItemRelation> ItemRelations { get; set; } = [];
    public ItemRelationType() { }
  }
}

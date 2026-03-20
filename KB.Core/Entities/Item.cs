using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Core.Entities {
  public class Item {
    public int Id { get; set; } = 0;
    public int ItemTypeId { get; set; } = 0;
    public string Name { get; set; }  = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Data { get; set; } = "{}";
    public DateTime Established { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;


    // Nav properties
    public ItemType ItemType { get; set; } = null!;
    public ICollection<ItemRelation> Relations { get; set; } = [];
    public ICollection<ItemRelation> IncomingRelations { get; set; } = [];


    public Item() { }

  }


}

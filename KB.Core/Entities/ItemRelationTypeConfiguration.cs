using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Core.Entities {
  public class ItemRelationTypeConfiguration : IEntityTypeConfiguration<ItemRelationType> {
    public void Configure(EntityTypeBuilder<ItemRelationType> builder) {
      builder.ToTable("ItemRelationTypes");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id).ValueGeneratedOnAdd();
      builder.Property(x => x.Relation).IsRequired().HasMaxLength(500);
      builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);
      builder.HasIndex(x => x.Relation).IsUnique();

    }
  }
}

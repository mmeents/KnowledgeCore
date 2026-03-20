using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace KB.Core.Entities {
  public class ItemTypeConfiguration : IEntityTypeConfiguration<ItemType> {
    public void Configure(EntityTypeBuilder<ItemType> builder) {
      builder.ToTable("ItemTypes");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id).ValueGeneratedOnAdd();
      builder.Property(x => x.Name).IsRequired().HasMaxLength(500);
      builder.Property(x => x.Description).HasMaxLength(-1);
      builder.HasIndex(x => x.Name).IsUnique();  


    }
  }
}

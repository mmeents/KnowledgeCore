using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KB.Core.Entities {
  public class ItemConfiguration : IEntityTypeConfiguration<Item> {
    public void Configure(EntityTypeBuilder<Item> builder) {
      builder.ToTable("Items");
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Id).ValueGeneratedOnAdd();
      builder.Property(x => x.Name).IsRequired().HasMaxLength(500);
      builder.Property(x => x.Description).HasMaxLength(-1);
      builder.Property(x => x.Data).HasColumnType("nvarchar(max)").HasDefaultValue("{}");
      builder.Property(x => x.IsActive).HasDefaultValue(true);
      builder.Property(x => x.Established).IsRequired().HasDefaultValueSql("GETUTCDATE()");

      builder.HasOne(x => x.ItemType)
        .WithMany(x => x.Items)
        .HasForeignKey(x => x.ItemTypeId)
        .OnDelete(DeleteBehavior.Restrict);
    }
  }
}

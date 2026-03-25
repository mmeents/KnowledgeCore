using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace KB.Core.Entities {
  public class ItemRelationConfiguration : IEntityTypeConfiguration<ItemRelation> {
    public void Configure(EntityTypeBuilder<ItemRelation> builder) {
      builder.ToTable("ItemRelations");
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Id).ValueGeneratedOnAdd();

      builder.Property(x => x.Established).IsRequired().HasDefaultValueSql("GETUTCDATE()");

      builder.HasOne(x => x.Item)
        .WithMany(x => x.Relations)
        .HasForeignKey(x => x.ItemId)
        .OnDelete(DeleteBehavior.Restrict);

      builder.HasOne(x => x.RelatedItem)
        .WithMany(x => x.IncomingRelations)
        .HasForeignKey(x => x.RelatedItemId)
        .IsRequired(false)
        .OnDelete(DeleteBehavior.Restrict);

      builder.HasOne(x => x.RelationType)
        .WithMany(x => x.ItemRelations)
        .HasForeignKey(x => x.RelationTypeId)
        .OnDelete(DeleteBehavior.Restrict);
      
      builder.HasIndex(x => new { x.ItemId, x.RelationTypeId, x.RelatedItemId }).IsUnique();
    }
  }
}

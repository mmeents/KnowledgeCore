using KB.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace KB.Core
{
  public class KbDbContext(DbContextOptions<KbDbContext> options) : DbContext(options) {

    public DbSet<Item> Items => Set<Item>();
    public DbSet<ItemType> ItemTypes => Set<ItemType>();    
    public DbSet<ItemRelation> ItemRelations => Set<ItemRelation>();
    public DbSet<ItemRelationType> ItemRelationTypes => Set<ItemRelationType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(KbDbContext).Assembly);
    }

    protected void ApplyKbConfigurations(ModelBuilder modelBuilder) {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(KbDbContext).Assembly);
    }
  }
}

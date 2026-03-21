using KB.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace KB.Core
{
  public class KbDbContext : DbContext {
        
    protected KbDbContext(DbContextOptions options) : base(options) {}
    public KbDbContext(DbContextOptions<KbDbContext> options) : base(options) {}


    public DbSet<Item> Items => Set<Item>();
    public DbSet<ItemType> ItemTypes => Set<ItemType>();    
    public DbSet<ItemRelation> ItemRelations => Set<ItemRelation>();
    public DbSet<ItemRelationType> ItemRelationTypes => Set<ItemRelationType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);      
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(KbDbContext).Assembly);
    }

  }
}

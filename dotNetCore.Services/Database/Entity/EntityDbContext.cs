using dotNetCore.Services.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace dotNetCore.Services.Database.Entity
{
  public class EntityDbContext : DbContext
  {
    public EntityDbContext(DbContextOptions<EntityDbContext> options) : base(options)
    {
    }

    public DbSet<User> User { get; set; }

    protected void RenewMacroColumn()
    {
      System.DateTime systemDateTime = System.DateTime.Now;
      foreach (var dbEntry in ChangeTracker.Entries())
      {
        switch (dbEntry.State)
        {
          case EntityState.Added:
            CreateWithValues(dbEntry, "Gid", System.Guid.NewGuid());
            CreateWithValues(dbEntry, "CreatedAt", systemDateTime);
            CreateWithValues(dbEntry, "UpdatedAt", systemDateTime);
            break;

          case EntityState.Modified:
            CreateWithValues(dbEntry, "UpdatedAt", systemDateTime);
            break;
        }
      }
    }

    private void CreateWithValues(Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry dbEntry, string propertyName, object value)
    {
      if (dbEntry.Property(propertyName) != null)
      {
        dbEntry.Property(propertyName).CurrentValue = value;
      }
    }
  }
}

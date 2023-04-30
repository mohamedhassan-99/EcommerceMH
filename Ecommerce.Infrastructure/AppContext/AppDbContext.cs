using Ecommerce.Core.IModel;
using Ecommerce.Core.Model;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.AppContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        BeforeSaving();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void BeforeSaving()
    {
        var entries = ChangeTracker.Entries();
        foreach (var entry in entries)
        {
            if(entry.Entity is IEntity trackableEntity)
            {
                switch (entry.State)
                {

                    case EntityState.Modified:
                        trackableEntity.ModifiedDate = DateTime.UtcNow;
                        trackableEntity.ModifiedBy = Guid.NewGuid();
                        break;
                    case EntityState.Added:
                        trackableEntity.CreatedDate = DateTime.UtcNow;
                        trackableEntity.CreatedBy = Guid.NewGuid();
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Brand> Brands { get; set; }
}

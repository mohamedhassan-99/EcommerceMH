using Ecommerce.Core.Model;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.EntityTypeConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Dummy1",
                Description = "Dummy Dummy1",
                CreatedBy = Guid.NewGuid(),
                BrandId = new Guid("55125622-b1f1-4a04-8e16-ce6d65fbe233"),

            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Dummy2",
                Description = "Dummy Dummy2",
                CreatedBy = Guid.NewGuid(),
                BrandId = new Guid("55125622-b1f1-4a04-8e16-ce6d65fbe233"),
            });
        builder.Property(a => a.CreatedDate).HasDefaultValue(DateTime.UtcNow);
        builder.Property(a => a.Id).HasDefaultValue(Guid.NewGuid());
        builder.HasOne(p => p.Brand).WithMany(c => c.Products);
        builder.HasMany(p => p.Categories).WithMany(c => c.Products);
    }
}

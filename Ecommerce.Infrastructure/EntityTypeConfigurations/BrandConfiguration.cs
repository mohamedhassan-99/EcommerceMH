using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.EntityTypeConfigurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(
                new Brand 
                {
                    Id = new Guid("55125622-b1f1-4a04-8e16-ce6d65fbe233"),
                    Name="LuftBorn",
                    Bio="Software House",
                    CreatedBy = Guid.NewGuid(),
                }
                );
        }
    }
}

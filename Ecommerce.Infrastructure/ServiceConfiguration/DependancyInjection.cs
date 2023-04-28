using Ecommerce.Infrastructure.AppContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Infrastructure.ServiceConfiguration;

public static class DependancyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer
            (
                configuration.GetConnectionString("DefualtConnection"),
                options => options.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
            );
        });
    }
}

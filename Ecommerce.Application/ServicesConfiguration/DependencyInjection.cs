using Ecommerce.Application.IServices;
using Ecommerce.Application.Services;
using Ecommerce.Infrastructure.BaseRepository;
using Ecommerce.Infrastructure.IBaseRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Application.ServicesConfiguration;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IProductService, ProductService>();
    }
}

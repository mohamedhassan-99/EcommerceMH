using Ecommerce.Application.IServices;
using Ecommerce.Application.Services;
using Ecommerce.Infrastructure;
using Ecommerce.Infrastructure.AppContext;
using Ecommerce.Infrastructure.BaseRepository;
using Ecommerce.Infrastructure.IBaseRepository;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.ServicesConfiguration
{
    public static class DependencyInjection
    {
        public static void Handle(IServiceCollection services)
        {
            services.AddDbContext<EcommerceDbContext>(options =>
            {
                options.UseSqlServer
                (
                    "Server = localhost; Database = EcommerceDb; trusted_connection=true;",
                    options => options.MigrationsAssembly("Ecommerce.Infrastructure")
                );
            });

            services.AddTransient<IRepository<Product>, Repository<Product>>();
            services.AddTransient<IRepository<Category>, Repository<Category>>();
            services.AddTransient<IRepository<Brand>, Repository<Brand>>();

            services.AddTransient<IUserService, UserService>();
        }
    }
}

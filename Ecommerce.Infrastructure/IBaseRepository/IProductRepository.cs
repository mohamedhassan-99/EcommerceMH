using Ecommerce.Core.Model;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.IBaseRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        public Task<Brand?> GetProductBrandAsync(Guid Id);
        public Task<List<Category>?> GetProductCategoriesAsync(Guid Id);
    }
}

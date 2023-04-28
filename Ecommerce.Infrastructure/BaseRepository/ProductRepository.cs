using Ecommerce.Core.IModel;
using Ecommerce.Infrastructure.AppContext;
using Ecommerce.Infrastructure.IBaseRepository;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.Infrastructure.BaseRepository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
            => _context = context;

        public override async Task<IList<Product>> GetAllAsync()
            => await _context.Products.AsNoTracking().Include(a => a.Brand).ToListAsync();
        public async Task<Brand?> GetProductBrandAsync(Guid id)
            => await _context.Products.AsNoTracking().Where(a => a.Id == id).Select(a => a.Brand).FirstOrDefaultAsync();

        public async Task<List<Category>?> GetProductCategoriesAsync(Guid id)
            => await _context.Products.AsNoTracking().Where(a => a.Id == id).Select(a => a.Categories).FirstOrDefaultAsync();

        

    }
}

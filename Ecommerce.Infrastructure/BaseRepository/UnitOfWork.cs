using Ecommerce.Infrastructure.AppContext;
using Ecommerce.Infrastructure.IBaseRepository;

namespace Ecommerce.Infrastructure.BaseRepository;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        
        ProductRepository = new ProductRepository(_context);
    }

    public IProductRepository ProductRepository { get; private set; }

    public async Task SaveAsync()
        => await _context.SaveChangesAsync();
}

using Ecommerce.Core.Enum;
using Ecommerce.Core.IModel;
using Ecommerce.Infrastructure.AppContext;
using Ecommerce.Infrastructure.IBaseRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.Infrastructure.BaseRepository
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
            => _context = context;
        public async Task CreateAsync(T model)
            => await _context.Set<T>().AddAsync(model);

        public async Task DeleteAsync(Guid id)
            => await _context.Set<T>().Where(a => a.Id == id).ExecuteDeleteAsync();

        public void Edit(T model)
            => _context.Set<T>().Update(model);

        public virtual async Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate, ProductIncludes includes)
            => await _context.Set<T>().Include(includes.ToString()).Where(predicate).SingleOrDefaultAsync();
        
        public async Task<T?> GetSingleAsync(Guid typeEntityId)
            => await _context.Set<T>().FindAsync(typeEntityId);
        
        public async Task<IList<T>> GetByAsync(Expression<Func<T, bool>> predicate)
            => await _context.Set<T>().Where(predicate).ToListAsync();

        public virtual async Task<IList<T>> GetAllAsync()
            => await _context.Set<T>().AsNoTracking().ToListAsync();

    }
}

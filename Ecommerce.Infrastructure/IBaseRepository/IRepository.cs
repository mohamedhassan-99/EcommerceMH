using Ecommerce.Core.Enum;
using Ecommerce.Core.IModel;
using System.Linq.Expressions;

namespace Ecommerce.Infrastructure.IBaseRepository;

public interface IRepository<T> where T : class, IEntity
{
    Task CreateAsync(T model);
    void Edit(T model);
    Task<IList<T>> GetAllAsync();
    Task<IList<T>> GetByAsync(Expression<Func<T, bool>> predicate);
    Task<T?> GetSingleAsync (Expression<Func<T, bool>> predicate, ProductIncludes includes);
    Task<T?> GetSingleAsync (Guid typeEntityId);
    Task DeleteAsync(Guid model);
    Task SaveAsync();
}

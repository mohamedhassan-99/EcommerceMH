using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.IBaseRepository
{

    public interface IRepository<T>
    {
        void Create(T model);
        T Edit(T model);
        IList<T> Get();
        IList<T> FindBy(Expression<Func<T, bool>> predicate);
        T FindOne (Expression<Func<T, bool>> predicate);
        void Delete(T model);
        void Save();
    }

}

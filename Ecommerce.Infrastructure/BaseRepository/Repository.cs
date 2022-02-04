using Ecommerce.Infrastructure.AppContext;
using Ecommerce.Infrastructure.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.BaseRepository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EcommerceDbContext _context;

        public Repository(EcommerceDbContext context)
        {
            _context = context;
        }
        public void Create(T model)
        {
            _context.Set<T>().Add(model);
            Save();
        }

        public void Delete(T model)
        {
            _context.Set<T>().Remove(model);
            Save();
        }

        public T Edit(T model)
        {
            _context.Set<T>().Update(model);
            Save();
            return model;
        }

        public T FindOne(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).SingleOrDefault();
        }

        public IList<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList<T>();
        }

        public IList<T> Get()
        {
            return _context.Set<T>().ToList<T>();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tienda.Domain.Interfaces.Repositories.Base;
using Tienda.PersistenceSQL.DataContext;

namespace Tienda.PersistenceSQL.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly TiendaContextSQL context;

        public BaseRepository(TiendaContextSQL context)
        {
            this.context = context;
        }

        public virtual async void Add(T entity)
        {
            await context.Set<T>().AddAsync(entity);
        }

        public virtual void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public virtual async Task<ICollection<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public virtual async Task<T?> GetById(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public virtual void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }

        public async Task<T?> Find(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>().FirstOrDefaultAsync(predicate);
        }
    }
}

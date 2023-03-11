using System.Linq.Expressions;

namespace Tienda.Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<T> where T : class
    {
        Task<ICollection<T>> GetAll();
        Task<T> GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> Find(Expression<Func<T, bool>> predicate);
    }
}

using Tienda.Domain.Entities;
using Tienda.Domain.Interfaces.Repositories.Base;

namespace Tienda.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IBaseRepository<ProductEntity>
    {
        Task<IEnumerable<ProductEntity>> GetAllWithPagination(int pageIndex, int pageSize);
    }
}

using Tienda.Domain.Interfaces.Services.Base;
using Tienda.Transversal.Helpers.Pagination;
using Transversal.ResponseData;

namespace Tienda.Domain.Interfaces.Services
{
    public interface IProductService <T,U,G> :  IBaseService<T,U> where T : class where U : class where G : class
    {
      
        Task<Response<Pager<IEnumerable<T>>>> GetAllPagination(int pageIndex, int pageSize);
    }

}

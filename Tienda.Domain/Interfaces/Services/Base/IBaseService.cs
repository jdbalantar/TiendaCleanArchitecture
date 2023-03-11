using Transversal.ResponseData;

namespace Tienda.Domain.Interfaces.Services.Base
{
    public interface IBaseService<T,U>  where T : class where U : class
    {
        Task<Response<ICollection<T>>> GetAll();
        Task<Response<T>> Create(U entity);
        Task<Response<T>> GetById(int id);
        Task<Response<T>> Update(int id, U entity);
        Task<Response<int>> Delete(int id);
    }
}

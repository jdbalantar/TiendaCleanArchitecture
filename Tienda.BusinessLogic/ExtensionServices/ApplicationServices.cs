using Microsoft.Extensions.DependencyInjection;
using Tienda.BusinessLogic.Services;
using Tienda.Domain.Interfaces.Services;
using Tienda.DTOs.Product;
using Tienda.Transversal.Helpers.Pagination;

namespace Tienda.BusinessLogic.ExtensionServices
{
    public static class ApplicationServices
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService<ProductDTO, ProductForCreateOrUpdateDTO, Pager<ProductDTO>>, ProductService>();
        }
    }
}

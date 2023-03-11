using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Tienda.Mappers.ExtensionServices
{
    public static class AddMappingServices
    {
        public static void AddAutoMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}

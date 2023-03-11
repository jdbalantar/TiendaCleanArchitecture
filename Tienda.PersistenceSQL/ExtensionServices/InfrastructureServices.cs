using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tienda.Domain.Interfaces;
using Tienda.PersistenceSQL.DataContext;

namespace Tienda.PersistenceSQL.ExtensionServices
{
    public static class InfrastructureServices
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration builder)
        {
            services.AddDbContext<TiendaContextSQL>(x => x.UseSqlServer(builder.GetConnectionString("SQLConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}

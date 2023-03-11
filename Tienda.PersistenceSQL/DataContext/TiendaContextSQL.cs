using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Tienda.Domain.Entities;

namespace Tienda.PersistenceSQL.DataContext
{
    public class TiendaContextSQL : DbContext
    {
        public TiendaContextSQL(DbContextOptions<TiendaContextSQL> options) : base(options)
        {

        }

        public DbSet<ProductEntity> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}

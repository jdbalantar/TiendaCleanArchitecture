using Microsoft.EntityFrameworkCore;
using Tienda.Domain.Entities;
using Tienda.Domain.Interfaces.Repositories;
using Tienda.PersistenceSQL.DataContext;
using Tienda.PersistenceSQL.Repositories.Base;

namespace Tienda.PersistenceSQL.Repositories
{
    public class ProductRepository : BaseRepository<ProductEntity>, IProductRepository
    {
        private readonly TiendaContextSQL context;

        public ProductRepository(TiendaContextSQL context) : base(context)
        {
            this.context = context;
        }


        public void Add(ProductEntity entity)   
        {
            context.Add(entity!);
        }

        public void Delete(ProductEntity entity)
        {
            context.Remove(entity!);
        }

        public async Task<ICollection<ProductEntity>> GetAll()
        {
            return (ICollection<ProductEntity>)await context.Products.ToListAsync();
        }

        public void Update(ProductEntity entity)
        {
            context.Update(entity);
        }

        public async Task<IEnumerable<ProductEntity>> GetAllWithPagination(int pageIndex, int pageSize)
        {
            int amountRegisters = await context.Products.CountAsync();
            IEnumerable<ProductEntity> productslists = await context.Products
                .Skip((pageIndex -1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (productslists);
        }


    }
}

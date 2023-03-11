using Tienda.Domain.Interfaces;
using Tienda.Domain.Interfaces.Repositories;
using Tienda.PersistenceSQL.DataContext;
using Tienda.PersistenceSQL.Repositories;

namespace Tienda.PersistenceSQL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TiendaContextSQL _context;

        private ProductRepository? _products;
        public IProductRepository Products
        {
            get
            {
                if (_products == null)
                    _products = new ProductRepository(_context);
                return _products;
            }
        }

        public UnitOfWork(TiendaContextSQL context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

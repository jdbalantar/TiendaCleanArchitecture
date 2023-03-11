using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Domain.Interfaces.Repositories;

namespace Tienda.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> Save();
        IProductRepository Products { get; }
        
    }
}

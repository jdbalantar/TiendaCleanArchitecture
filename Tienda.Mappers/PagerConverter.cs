using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Transversal.Helpers.Pagination;

namespace Tienda.Mappers
{
    internal class PagerConverter
    {
        class Converter<TSource, TDest> : ITypeConverter<Pager<TSource>, Pager<TDest>>
        {
            public Pager<TDest> Convert(Pager<TSource> source, Pager<TDest> destination, ResolutionContext context) => new Pager<TDest>(context.Mapper.Map<IEnumerable<TDest>>(source.AsEnumerable()), source.Paging);
        }
    }
}

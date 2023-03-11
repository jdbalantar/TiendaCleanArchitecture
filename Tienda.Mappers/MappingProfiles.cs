using AutoMapper;
using Tienda.Domain.Entities;
using Tienda.DTOs.Product;
using Tienda.Transversal.Helpers.Pagination;

namespace Tienda.Mappers
{
    internal class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProductDTO, ProductEntity>()
                .ReverseMap();

            CreateMap<ProductForCreateOrUpdateDTO, ProductEntity>()
                .ReverseMap();

            CreateMap(typeof(Pager<IEnumerable<ProductEntity>>), typeof(Pager<IEnumerable<ProductDTO>>)).ReverseMap();
            CreateMap(typeof(Pager<>), typeof(Pager<>)).ReverseMap();
        }
    }
}

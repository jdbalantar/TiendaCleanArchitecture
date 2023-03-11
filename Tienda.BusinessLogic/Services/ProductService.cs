using AutoMapper;
using System.Net;
using Tienda.Domain.Entities;
using Tienda.Domain.Interfaces;
using Tienda.Domain.Interfaces.Services;
using Tienda.DTOs.Product;
using Tienda.Transversal.Helpers.Pagination;
using Transversal.Exceptions;
using Transversal.ResponseData;

namespace Tienda.BusinessLogic.Services
{
    public class ProductService : IProductService<ProductDTO, ProductForCreateOrUpdateDTO, Pager<ProductDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Response<ICollection<ProductDTO>>> GetAll()
        {
            Response<ICollection<ProductDTO>> response = new();
            List<ProductDTO> productsDTOs = new();
            ICollection<ProductEntity> products = await unitOfWork.Products.GetAll();

            productsDTOs = mapper.Map<List<ProductDTO>>(products);

            response.Data = productsDTOs;

            return response;
        }

        public async Task<Response<ProductDTO>> GetById(int id)
        {
            ProductDTO? productDTO = null;
            Response<ProductDTO> response = new();
            ProductEntity? product = null;

            if (id == null)
                throw new RestException(HttpStatusCode.BadRequest, "Se debe enviar el id");

            product = await unitOfWork.Products.GetById(id);

            if (product == null)
                throw new RestException(HttpStatusCode.NotFound, "No se encontró el producto solicitado");

            productDTO = mapper.Map<ProductDTO>(product);

            response.Data = productDTO;

            return response;
        }

        public async Task<Response<ProductDTO>> Create(ProductForCreateOrUpdateDTO productDTO)
        {
            Response<ProductDTO> response = new();

            if (productDTO == null || productDTO.Name == null)
                throw new RestException(HttpStatusCode.BadRequest, "");

            ProductEntity product = new ProductEntity { Name = productDTO.Name };

            unitOfWork.Products.Add(product);
            await unitOfWork.Save();

            ProductEntity productCreated = await unitOfWork.Products.Find(x => x.Name == productDTO.Name);

            ProductDTO newProductDto = mapper.Map<ProductDTO>(productCreated);

            response.Data = newProductDto;
            response.Message = "Producto creado con exito.";

            return response;
        }

        public async Task<Response<int>> Delete(int id)
        {
            Response<int> response = new();

            ProductEntity product = await unitOfWork.Products.GetById(id);

            unitOfWork.Products.Delete(product);
            response.Data = await unitOfWork.Save();

            response.Message = "El producto se eliminó correctamente";
            return response;

        }

        public async Task<Response<ProductDTO>> Update(int id, ProductForCreateOrUpdateDTO productDTO)
        {
            Response<ProductDTO> response = new();

            ProductEntity productFound = await unitOfWork.Products.GetById(id);

            if (productFound == null)
                throw new RestException(HttpStatusCode.NotFound, "No se encontró el producto");

            productFound.Name = productDTO.Name;

            unitOfWork.Products.Update(productFound);
            await unitOfWork.Save();

            ProductDTO product = mapper.Map<ProductDTO>(productFound);
            response.Data = product;

            return response;
        }

        public async Task<Response<Pager<IEnumerable<ProductDTO>>>> GetAllPagination(int pageIndex, int pageSize)
        {
            Response<Pager<IEnumerable<ProductDTO>>> response = new();
            var productsPagination = await unitOfWork.Products.GetAllWithPagination(pageIndex, pageSize);


            
            Pager<IEnumerable<ProductDTO>> productDTO = mapper.Map<Pager<IEnumerable<ProductDTO>>>(productsPagination);

            response.Data = productDTO;

            return response;
        }
    }
}
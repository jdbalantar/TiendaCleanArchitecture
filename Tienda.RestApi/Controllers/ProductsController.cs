using Microsoft.AspNetCore.Mvc;
using Tienda.Domain.Interfaces.Services;
using Tienda.DTOs.Product;
using Tienda.Transversal.Helpers.Pagination;
using Transversal.ResponseData;


namespace Tienda.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService<ProductDTO, ProductForCreateOrUpdateDTO,Pager<ProductDTO>> productService;

        public ProductsController(IProductService<ProductDTO, ProductForCreateOrUpdateDTO, Pager<ProductDTO>> productService)
        {
            this.productService = productService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await productService.GetAll());
        }
        [HttpGet("Pagination")]
        public async Task<IActionResult> GetProducts([FromQuery] Params paginationParams)
        {
            return Ok(await productService.GetAllPagination(paginationParams.PageIndex, paginationParams.PageSize));
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await productService.GetById(id));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductForCreateOrUpdateDTO product)
        {
            return Ok(await productService.Update(id, product));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductForCreateOrUpdateDTO product)
        {
            return Ok(await productService.Create(product));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<int>> DeleteProduct(int id)
        {
            return Ok(await productService.Delete(id));
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetProductByName(string name)
        {
            return Ok();//await productService.GetIdByName(name));
        }
    }
}

using BLL.System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;


        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet("")]
        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var products = await _productManager.GetProducts();

            return products;
        }

        [HttpGet("{id:int}")]
        public async Task<ProductDto?> GetProduct(int id)
        {
            var products = await _productManager.GetProductById(id);

            return products;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Add")]
        public async Task AddPrdouct(ProductCreateDto  p)
        {
            await _productManager.Create(p);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete/{id:int}")]
        public async Task Delete(int id)
        {
            await _productManager.Delete(id);
        }
    }
}

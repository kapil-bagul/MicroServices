using System;
using System.Threading.Tasks;
using eCommerce.api.product.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace eCommerce.api.product.Controllers
{
    [ApiController]
    
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductProvider productProvider;

        public ProductController(IProductProvider productProvider)
        {
            this.productProvider = productProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var result=  await this.productProvider.GetProductsAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Products);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await this.productProvider.GetProductAsync(id);
            if (result.IsSuccess)
            {
               return Ok(result.Products);
            }

            return BadRequest();
        }


    }
}

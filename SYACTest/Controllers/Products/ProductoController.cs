using Microsoft.AspNetCore.Mvc;
using SYACTest.DTOs;
using SYACTest.Services.ProductsServices;

namespace SYACTest.Controllers.Products
{
    [ApiController]
    [Route("Api/Products")]
    public class ProductoController : ControllerBase
    {
        public ProductoController(IProductService productService)
        {
            ProductService = productService;
        }

        public IProductService ProductService { get; }

        [HttpGet]
        [Route("getproductslist")]
        public async Task<IActionResult> getlist()
        {
            var ServiceResponse = await ProductService.getlist();
            switch (ServiceResponse.statusCode)
            {
                case 200:
                    return Ok(ServiceResponse);
                case 400:
                    return BadRequest(ServiceResponse);
                default:
                    return BadRequest(ServiceResponse);
            }
        }


        [HttpPost]
        [Route("CreateProducts")]
        public async Task<IActionResult> CreateProducts([FromBody]List<ProductsDTO> products)
        {
            var ServiceResponse = await ProductService.createproducto(products);
            switch (ServiceResponse.statusCode)
            {
                case 200:
                    return Ok(ServiceResponse);
                case 400:
                    return BadRequest(ServiceResponse);
                default:
                    return BadRequest(ServiceResponse);
            }
        }

    }
}

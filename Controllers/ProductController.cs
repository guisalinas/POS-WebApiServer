using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using POS_ApiServer.DTOs.Product;
using POS_ApiServer.Services;

namespace POS_ApiServer.Controllers
{
    [Route("/api")]
    [ApiController]
    public class ProductController : ControllerBase
    {
         private IProductService _productService;

         public ProductController(IProductService productService)
         {
             this._productService = productService;
         }
  

        [HttpPost("/product")]
        public async Task<IActionResult> AddProduct([FromBody] addProductDTO productDTO)
        {
            try
            {
                await _productService.AddProduct(productDTO);

                return Ok();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpPut("/product/update")]
        public async Task<IActionResult> UpdateProduct([FromBody] updateProductDTO productDTO, long id)
        {
            try
            {
                await _productService.UpdateProduct(productDTO, id);

                return Ok("The product has been updated succesfully");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción interna: " + ex.InnerException?.Message);
                throw new Exception(ex.Message);
            }
        }

    }
}

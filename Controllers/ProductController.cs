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

        [HttpGet("/products")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var productList = await _productService.GetProductsAsync();
                
                if (productList.Any() )
                {
                    return Ok(productList);
                }
                else
                {
                    return Ok("No products ar available yet");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("/products/{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] long id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
               
                if (product == null){
                    return Ok("There is no product with that ID");
                }

                return Ok(product);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("/product")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDTO productDTO)
        {
            try
            {
                var newProduct = await _productService.AddProductAsync(productDTO);
                
                if (newProduct == null) {
                    return BadRequest("Oops! The product could not be created" );
                }

                return Ok(newProduct);               

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("/product/update")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDTO updateProductDTO)
        {
            try
            {
                var product = await _productService.UpdateProductAsync(updateProductDTO);

                if (product)
                {
                    return Ok("The product has been updated succesfully");
                }
                else
                {
                    return BadRequest("Oops! The product has been not updated.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción interna: " + ex.InnerException?.Message);
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("/product/detete")]
        public async Task<IActionResult> LogicDeleteProduct([FromBody] LogicalDeleteProductDTO deleteProductDTO)
        {
            try
            {
                var product = await _productService.LogicalDeleteProductAsync(deleteProductDTO);
                
                if (product)
                {
                    return Ok("The product has been deleted");
                }
                else
                {
                    return BadRequest("Oops! There was an error in deleting the product");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción interna: " + ex.InnerException?.Message);
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("/product/recover")]
        public async Task<IActionResult> RecoverProduct([FromBody] LogicalDeleteProductDTO recoverProductDTO)
        {
            try
            {
                var product = await _productService.RecoverProductAsync(recoverProductDTO);

                if (product)
                {
                    return Ok("The product has been recovered");
                }
                else
                {
                    return BadRequest("Oops! There was an error in revocer the product");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción interna: " + ex.InnerException?.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using POS_ApiServer.Data;
using POS_ApiServer.DTOs.Product;
using POS_ApiServer.Models;

namespace POS_ApiServer.Services.Implements
{
    public class ProductService : IProductService
    {
        private DBContext _DBContext;
        private IMapper _mapper;

        public ProductService(DBContext dbContext, IMapper mapper)
        {
            _DBContext = dbContext;
            _mapper = mapper;
        }

        public async Task<addProductDTO> AddProduct(addProductDTO productDTO)
        {
            try
            {
                var product = _mapper.Map<Product>(productDTO);

                _DBContext.Products.Add(product);
                await _DBContext.SaveChangesAsync();

                return productDTO;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateProduct(updateProductDTO productDTO, long id)
        {
            try
            {
               var productToUpdate = await _DBContext.Products.FindAsync(id);
                
                if (productToUpdate != null) {
                    var product = _mapper.Map(productDTO, productToUpdate);

                    _DBContext.Products.Update(product);

                    await _DBContext.SaveChangesAsync();

                    return true;
                }else 
                { 
                    return false; 
                
                } 
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

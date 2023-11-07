using AutoMapper;
using POS_ApiServer.Data;
using Microsoft.EntityFrameworkCore;
using POS_ApiServer.DTOs.Product;
using POS_ApiServer.Models;
using POS_ApiServer.Repositories;
using POS_ApiServer.Repositories.Implements;

namespace POS_ApiServer.Services.Implements
{
    public class ProductService : IProductService
    {
        private IMapper _mapper;

        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this._mapper = mapper;
            this._productRepository = productRepository;
        }

        public async Task<List<GetProductDTO>> GetProductsAsync()
        {
            try
            {
                var products = await _productRepository.GetAllAsync();
                var productsDTOList = _mapper.Map<List<GetProductDTO>>(products);
                return productsDTOList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<ProductDTO> AddProductAsync(ProductDTO productDTO)
        {
            try
            {

                var product = await _productRepository.AddAsync( _mapper.Map<Product>(productDTO) );              

                return _mapper.Map<ProductDTO>(product);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
             
        public async Task<bool> LogicalDeleteProductAsync(LogicalDeleteProductDTO deleteProductDTO)
        {
            try
            {
               
                var product = await _productRepository.GetByIdAsync(deleteProductDTO.id);

                if (product != null)
                {
                    _mapper.Map(deleteProductDTO, product);
                    return await _productRepository.LogicalDeleteAsync(product);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductDTO> GetProductByIdAsync(long id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);


                if (product != null)
                {
                    var productDTO = _mapper.Map<ProductDTO>(product);

                    return productDTO;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateProductAsync(UpdateProductDTO updateProductDTO)
        {
            try
            {
                
                var product = await _productRepository.GetByIdAsync(updateProductDTO.id);
                
                if ( product != null )
                {
                    _mapper.Map(updateProductDTO, product);

                    return await _productRepository.UpdateAsync(product);
                }

                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> RecoverProductAsync(LogicalDeleteProductDTO recoverProductDTO)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(recoverProductDTO.id);

                if (product != null)
                {
                    _mapper.Map(recoverProductDTO, product);
                    return await _productRepository.RecoverAsync(product);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ExistsByProductCodeAsync(string productCode)
        {
            try
            {
                return await _productRepository.ExistsByProductCode(productCode);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }

}

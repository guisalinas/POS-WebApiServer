using AutoMapper;
using POS_ApiServer.DTOs.Product;

namespace POS_ApiServer.Services
{
    public interface IProductService
    {
        public Task<addProductDTO> AddProduct(addProductDTO productDTO);
        Task<bool> UpdateProduct(updateProductDTO productDTO, long id);

    }
}

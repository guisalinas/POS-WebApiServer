using POS_ApiServer.DTOs.Product;

namespace POS_ApiServer.Services
{
    public interface IProductService
    {
        Task<ProductDTO> AddProductAsync(ProductDTO productDTO);
        Task<bool> UpdateProductAsync(UpdateProductDTO productDTO);
        Task<bool> LogicalDeleteProductAsync(LogicalDeleteProductDTO deleteProductDTO);
        Task<ProductDTO> GetProductByIdAsync(long id);
        Task<List<GetProductDTO>> GetProductsAsync();
        Task<bool> RecoverProductAsync(LogicalDeleteProductDTO recoverProductDTO);
        Task<bool> ExistsByProductCodeAsync(string productCode);
    }
}

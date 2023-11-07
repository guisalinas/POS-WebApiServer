using POS_ApiServer.DTOs.Product;

namespace POS_ApiServer.Services
{
    public interface IProductService
    {
        Task<ProductDTO> AddProduct(ProductDTO productDTO);
        Task<bool> UpdateProduct(UpdateProductDTO productDTO);
        Task<bool> LogicalDeleteProduct(LogicalDeleteProductDTO deleteProductDTO);
        Task<ProductDTO> GetProductById(long id);
        Task<List<GetProductDTO>> GetProducts();
        Task<bool> RecoverProductAsync(LogicalDeleteProductDTO recoverProductDTO);
        Task<bool> ExistsByProductCode(string productCode);
    }
}

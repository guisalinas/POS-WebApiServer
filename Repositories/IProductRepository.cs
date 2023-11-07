using POS_ApiServer.DTOs.Product;
using POS_ApiServer.Models;

namespace POS_ApiServer.Repositories
{
    public interface IProductRepository
    {
        Task <Product> GetByIdAsync (long id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> AddAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        Task<bool> LogicalDeleteAsync(Product product);
        Task<bool> RecoverAsync(Product product);
        Task<bool> ExistsByProductCode(string productCode);
    }
}

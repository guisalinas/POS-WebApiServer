using POS_ApiServer.Models;
using POS_ApiServer.Data;
using Microsoft.EntityFrameworkCore;

namespace POS_ApiServer.Repositories.Implements
{
    public class ProductRepository : IProductRepository
    {
        private DBContext _dbContext;
        public ProductRepository(DBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Product> AddAsync(Product product)
        {
            try
            {
                _dbContext.Products.Add(product);
                await _dbContext.SaveChangesAsync();

                return product;

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<Product> GetByIdAsync(long id)
        {
            try
            {   
                return await _dbContext.Products.FirstOrDefaultAsync(p => p.id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            try
            {
                _dbContext.Products.Update(product);
                await _dbContext.SaveChangesAsync();
                return true;            

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> LogicalDeleteAsync(Product product)
        {
            try
            {
                    product.isDeleted = true;
                    await _dbContext.SaveChangesAsync();
                    return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> RecoverAsync(Product product)
        {
            try
            {
                product.isDeleted = false;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ExistsByProductCode(string productCode)
        {
            return await _dbContext.Products.AnyAsync(pc => pc.productCode == productCode);
        }
    }
}

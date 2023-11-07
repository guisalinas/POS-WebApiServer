using Microsoft.EntityFrameworkCore;
using POS_ApiServer.Data;
using POS_ApiServer.Models;

namespace POS_ApiServer.Repositories.Implements
{
    public class CustomerRepository : IcustomerRepository
    {
        private readonly DBContext _dbContext;

        public CustomerRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Customers.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Customer> GetByIdAsync(long id)
        {
            try
            {
                return await _dbContext.Customers.FirstOrDefaultAsync(c => c.id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            try
            {
                _dbContext.Customers.Add(customer);
                await _dbContext.SaveChangesAsync();

                return customer;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateAsync(Customer customer)
        {
            try
            {
                _dbContext.Customers.Update(customer);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> LogicalDeleteAsync(Customer customer)
        {
            try
            {
                customer.isDeleted = true;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> RecoverAsync(Customer customer)
        {
            try
            {
                customer.isDeleted = false;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

using POS_ApiServer.Models;

namespace POS_ApiServer.Repositories
{
    public interface IcustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(long id);
        Task<Customer> AddAsync(Customer customer);
        Task<bool> UpdateAsync(Customer customer);
        Task<bool> LogicalDeleteAsync(Customer customer);
        Task<bool> RecoverAsync(Customer customer);
    }
}

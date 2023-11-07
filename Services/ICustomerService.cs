using POS_ApiServer.DTOs.Customer;

namespace POS_ApiServer.Services
{
    public interface ICustomerService
    {
        Task<CustomerDTO> AddCustomerAsync(CustomerDTO customerDTO);
        Task<bool> UpdateCustomerAsync(UpdateCustomerDTO customerDTO);
        Task<bool> LogicalDeleteCustomerAsync(LogicalDeleteCustomerDTO deleteCustomerDTO);
        Task<GetCustomerDTO> GetCustomerByIdAsync(long id);
        Task<List<GetCustomerDTO>> GetCustomersAsync();
        Task<bool> RecoverCustomerAsync(LogicalDeleteCustomerDTO deleteCustomerDTO);
    }
}

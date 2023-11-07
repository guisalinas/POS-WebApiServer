using AutoMapper;
using POS_ApiServer.DTOs.Customer;

using POS_ApiServer.Models;
using POS_ApiServer.Repositories;
using POS_ApiServer.Repositories.Implements;


namespace POS_ApiServer.Services.Implements
{
    public class CustomerService : ICustomerService
    {
        private IMapper _mapper;
        private IcustomerRepository _customerRepository;

        public CustomerService(IMapper mapper, IcustomerRepository personRepository)
        {
           this._mapper = mapper;
           this._customerRepository = personRepository;
        }
        public async Task<CustomerDTO> AddCustomerAsync(CustomerDTO customerDTO)
        {
            try
            {
                var customer = await _customerRepository.AddAsync( _mapper.Map<Customer>(customerDTO));

                return _mapper.Map<CustomerDTO>(customer);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetCustomerDTO> GetCustomerByIdAsync(long id)
        {
            try
            {
                var customer = await _customerRepository.GetByIdAsync(id);


                if (customer != null)
                {
                    var customerDTO = _mapper.Map<GetCustomerDTO>(customer);

                    return customerDTO;
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

        public async Task<List<GetCustomerDTO>> GetCustomersAsync()
        {
            try
            {
                var customers = await _customerRepository.GetAllAsync();
                var customersDTOList = _mapper.Map<List<GetCustomerDTO>>(customers);
                return customersDTOList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> LogicalDeleteCustomerAsync(LogicalDeleteCustomerDTO deleteCustomerDTO)
        {
            try
            {
                var customer = await _customerRepository.GetByIdAsync(deleteCustomerDTO.id);

                if (customer != null)
                {
                    _mapper.Map(deleteCustomerDTO, customer);
                    return await _customerRepository.LogicalDeleteAsync(customer);
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

        public async Task<bool> RecoverCustomerAsync(LogicalDeleteCustomerDTO recoverCustomerDTO)
        {
            try
            {
                var customer = await _customerRepository.GetByIdAsync(recoverCustomerDTO.id);

                if (customer != null)
                {
                    _mapper.Map(recoverCustomerDTO, customer);
                    return await _customerRepository.RecoverAsync(customer);
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

        public async Task<bool> UpdateCustomerAsync(UpdateCustomerDTO updateCustomerDTO)
        {
            try
            {
                var customer = await _customerRepository.GetByIdAsync(updateCustomerDTO.id);

                if (customer != null)
                {
                    _mapper.Map(updateCustomerDTO, customer);

                    return await _customerRepository.UpdateAsync(customer);
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
    }
}

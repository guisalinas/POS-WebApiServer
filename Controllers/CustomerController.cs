using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using POS_ApiServer.DTOs.Customer;
using POS_ApiServer.DTOs.Product;
using POS_ApiServer.Services;
using POS_ApiServer.Services.Implements;


namespace POS_ApiServer.Controllers
{
    [ApiController]
    [Route("/api")]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;
        private IAddressService _addressService;

        public CustomerController(ICustomerService customerService, IAddressService addressService)
        {
            _customerService = customerService;
            _addressService = addressService;
        }


        [HttpPost("/customer")]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerDTO customerDTO)
        {
            try
            {
                if (string.IsNullOrEmpty(customerDTO.dni) || string.IsNullOrEmpty(customerDTO.name) || string.IsNullOrEmpty(customerDTO.surname))
                {
                    return BadRequest("Some fields are empty. Check them!");
                }

                var newCustomer = await _customerService.AddCustomerAsync(customerDTO);

                if (newCustomer == null)
                {
                    return BadRequest("Oops! The customer could not be created");
                }

                return Ok(newCustomer);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("/customers")]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var customersList = await _customerService.GetCustomersAsync();

                if (customersList.Any())
                {
                    return Ok(customersList);
                }
                else
                {
                    return Ok("No customers at register yet");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("/customer/{id}")]
        public async Task<IActionResult> CustomerProduct([FromRoute] long id)
        {
            try
            {
                var customer = await _customerService.GetCustomerByIdAsync(id);

                if (customer == null)
                {
                    return Ok("There is no customer with that ID");
                }
                return Ok(customer);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("/customer/detete")]
        public async Task<IActionResult> LogicDeleteCustomer([FromBody] LogicalDeleteCustomerDTO deleteCustomerDTO)
        {
            try
            {
                var product = await _customerService.LogicalDeleteCustomerAsync(deleteCustomerDTO);

                if (product)
                {
                    return Ok("The customer has been deleted");
                }
                else
                {
                    return BadRequest("Oops! There was an error in deleting the customer");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción interna: " + ex.InnerException?.Message);
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("/customer/recover")]
        public async Task<IActionResult> RecoverCustomer([FromBody] LogicalDeleteCustomerDTO recoverCustomerDTO)
        {
            try
            {
                var customer = await _customerService.RecoverCustomerAsync(recoverCustomerDTO);

                if (customer)
                {
                    return Ok("The customer has been recovered");
                }
                else
                {
                    return BadRequest("Oops! There was an error in revocer the customer");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción interna: " + ex.InnerException?.Message);
                throw new Exception(ex.Message);
            }
        }


        [HttpPut("/customer/update")]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerDTO updatecustomerDTO)
        {
            try
            {
                var customer = await _customerService.UpdateCustomerAsync(updatecustomerDTO);

                if (customer)
                {
                    return Ok("The customer has been updated succesfully");
                }
                else
                {
                    return BadRequest("Oops! The customer has been not updated.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción interna: " + ex.InnerException?.Message);
                throw new Exception(ex.Message);
            }
        }

    }
}

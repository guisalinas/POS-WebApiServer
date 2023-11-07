using Microsoft.AspNetCore.Mvc;
using POS_ApiServer.DTOs.Customer;
using POS_ApiServer.Services;


namespace POS_ApiServer.Controllers
{
    [ApiController]
    [Route("/api")]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpPost("/customer")]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerDTO customerDTO)
        {
            try
            {
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
        public async Task<IActionResult> RecoverProduct([FromBody] LogicalDeleteCustomerDTO recoverCustomerDTO)
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





    }
}

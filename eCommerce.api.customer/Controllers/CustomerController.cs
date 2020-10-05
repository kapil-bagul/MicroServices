using System;
using System.Threading.Tasks;
using eCommerce.api.product.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.api.product.Controllers
{
    [ApiController]
    [Route("api/customers")]
    
    public class CustomerController: ControllerBase
    {
        private readonly ICustomerProvider customerProvider;

        public CustomerController(ICustomerProvider customerProvider) 
        {
            this.customerProvider = customerProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomersAsync()
        {
           
                var result = await customerProvider.GetCustomers();
                if(result.IsSuccess)
                {
                    return Ok(result.customer);
                    
                }

            return BadRequest();
           
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCustomer(int Id)
        {
            var result = await customerProvider.GetCustomer(Id);
            if (result.IsSuccess)
            {
                return Ok(result.customer);
            }

            return BadRequest();
        }

       
    }
}

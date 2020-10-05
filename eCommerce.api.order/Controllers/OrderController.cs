using System;
using System.Threading.Tasks;
using eCommerce.api.order.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.api.order.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderProvider orderProvider;

        public OrderController( IOrderProvider orderProvider )
        {
            this.orderProvider = orderProvider;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetOrdersAync(int customerId)
        {
            var orders = await orderProvider.GetOrdersAsync(customerId);
            if(orders.IsSuccess)
            {
                return Ok(orders.order);
            }

            return BadRequest();


        }

        
    }
}

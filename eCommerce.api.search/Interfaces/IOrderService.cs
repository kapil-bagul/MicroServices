using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerce.api.search.Models;

namespace eCommerce.api.search.Interfaces
{
    public interface IOrderService
    {
       Task<(bool IsSuccess, IEnumerable<Order> orders, string errorMessage)>   GetOrderAsync(int customerId);
    }
}

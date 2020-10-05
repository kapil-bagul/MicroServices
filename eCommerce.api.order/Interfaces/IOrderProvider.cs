using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.api.order.Interfaces
{
    public interface IOrderProvider
    {
        Task<(bool IsSuccess, IEnumerable<Models.Order> order, string ErrorMessage)> GetOrdersAsync(int customerId);
    }
}

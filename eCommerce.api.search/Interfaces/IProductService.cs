using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerce.api.search.Models;

namespace eCommerce.api.search.Interfaces
{
    public interface IProductService
    {
        Task<(bool IsSuccess, IEnumerable<Product> products, string errorMessage)> GetProductAsync();
    }
}

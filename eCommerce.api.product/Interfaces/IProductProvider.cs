using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerce.api.product.models;

namespace eCommerce.api.product.Interfaces
{
    public interface IProductProvider
    {
        Task<(bool IsSuccess, IEnumerable<eCommerce.api.product.models.Product> Products,
            string errorMessage)> GetProductsAsync();

        Task<(bool IsSuccess, eCommerce.api.product.models.Product Products,
           string errorMessage)> GetProductAsync(int Id);
    }
}

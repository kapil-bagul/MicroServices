using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerce.api.product.models;

namespace eCommerce.api.product.Interfaces
{
    public interface ICustomerProvider
    {
        Task<(bool IsSuccess, IEnumerable<Customer> customer, string errorMessage)> GetCustomers();
        Task<(bool IsSuccess, Customer customer, string errorMessage)> GetCustomer(int id);

        
    }
}

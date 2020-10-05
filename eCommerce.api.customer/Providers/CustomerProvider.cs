using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eCommerce.api.product.dbContext;
using eCommerce.api.product.Interfaces;
using eCommerce.api.product.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace eCommerce.api.product.Providers
{
    public class CustomerProvider: ICustomerProvider
    {
        private readonly IMapper mapper;
        private readonly CustomerDbContext customerDbContext;
        private readonly ILogger logger;

        public CustomerProvider(IMapper mapper, CustomerDbContext customerDbContext, ILogger<CustomerProvider> logger)
        {
            this.mapper = mapper;
            this.customerDbContext = customerDbContext;
            this.logger = logger;
            SeedCustomer();
        }

        private void SeedCustomer()
        {
            if (!this.customerDbContext.Customers.Any())
            {
                customerDbContext.Customers.Add(new db.Customer() { Id = 1, Name = "Kapil Bagul", Address = "4132 Providence Rd" });
                customerDbContext.Customers.Add(new db.Customer() { Id = 2, Name = "Shreya Bagul", Address = "4133 Providence Rd" });
                customerDbContext.Customers.Add(new db.Customer() { Id = 3, Name = "Pratibha Bagul", Address = "4134 Providence Rd" });
                customerDbContext.Customers.Add(new db.Customer() { Id = 4, Name = "Kashvi Bagul", Address = "4135 Providence Rd" });

                customerDbContext.SaveChanges();
            }

               
        }

        public async Task<(bool IsSuccess, Customer customer, string errorMessage)> GetCustomer(int id)
        {
            try
            {
                var result = await customerDbContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
                if(result !=null)
                {
                    var customer = mapper.Map<db.Customer, Customer>(result);
                    return (true, customer, null);
                }

                return (false, null, "No Customer Found");


            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Customer> customer, string errorMessage)> GetCustomers()
        {
            try
            {
                var result = await customerDbContext.Customers.ToListAsync();
                if(result !=null && result.Any())
                {
                    var customers = mapper.Map<IEnumerable<db.Customer>, IEnumerable<models.Customer>>(result);
                    return (true, customers, null);
                }

                return (false, null, "No Customer found");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }
    }
}

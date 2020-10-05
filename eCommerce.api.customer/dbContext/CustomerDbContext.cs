using System;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.api.product.dbContext
{
    public class CustomerDbContext: DbContext
    {
        public DbSet<db.Customer> Customers { get; set; }
        public CustomerDbContext( DbContextOptions options  ): base(options)
        {
        }
    }
}

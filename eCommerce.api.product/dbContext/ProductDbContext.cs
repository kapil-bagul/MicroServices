using System;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.api.product.dbContext
{
    public class ProductDbContext : DbContext
    {
        public DbSet<product.db.Product> Products { get; set; }
        public ProductDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}

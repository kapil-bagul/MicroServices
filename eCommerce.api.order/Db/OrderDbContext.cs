using System;
using Microsoft.EntityFrameworkCore;
namespace eCommerce.api.order.Db
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Db.Order> Order { get; set; }
        public DbSet<Db.OrderItem> OrderItem { get; set; }
        public OrderDbContext(DbContextOptions options): base(options)
        {
        }
    }
}

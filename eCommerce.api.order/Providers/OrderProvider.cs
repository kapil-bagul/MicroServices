using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eCommerce.api.order.Db;
using eCommerce.api.order.Interfaces;
using eCommerce.api.order.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderItem = eCommerce.api.order.Db.OrderItem;

namespace eCommerce.api.order.Providers
{
    public class OrderProvider : IOrderProvider
    {
        private readonly ILogger<IOrderProvider> logger;
        private readonly OrderDbContext orderDbContext;
        private readonly IMapper mapper;

        public OrderProvider(ILogger<IOrderProvider> logger, OrderDbContext orderDbContext, IMapper mapper )
        {
            this.logger = logger;
            this.orderDbContext = orderDbContext;
            this.mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {
            if (!orderDbContext.Order.Any())
            {
                orderDbContext.Order.Add(new Db.Order()
                {
                    Id = 1,
                    CustomerId = 1,
                    OrderDate = DateTime.Now,
                    Items = new List<OrderItem>()
                    {
                        new OrderItem() { Id = 1,  ProductId = 1, Quantity = 10, Price = 10 },
                        new OrderItem() { Id = 2, ProductId = 2, Quantity = 10, Price = 10 },
                        new OrderItem() { Id = 3, ProductId = 3, Quantity = 10, Price = 10 },
                        new OrderItem() { Id = 4, ProductId = 2, Quantity = 10, Price = 10 },
                        new OrderItem() { Id = 5, ProductId = 3, Quantity = 1, Price = 100 }
                    },
                    Total = 100
                });

                orderDbContext.Order.Add(new Db.Order()
                {
                    Id=2,
                    CustomerId=1,
                    OrderDate=DateTime.Now,
                    Total=5,
                    Items=new List<OrderItem>()
                    {
                        new OrderItem(){Id=6, ProductId=1, Price=5, Quantity=10 },
                        new OrderItem(){Id=7, ProductId=2, Price=10, Quantity=20 },
                    }
                    
                });
               
               
                orderDbContext.SaveChanges();
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Models.Order> order, string ErrorMessage)> GetOrdersAsync(int customerId)
        {
            try
            {
                var orders = await this.orderDbContext.Order.Where(c => c.CustomerId == customerId)
                    .Include(o => o.Items)
                    .ToListAsync();
                if(orders != null && orders.Any())
                {
                    var result = mapper.Map<IEnumerable<Db.Order>,
                       IEnumerable<Models.Order>>(orders);
                    return (true,  result, null);
                }

                return (false, null, "Order not found");
                


            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);

            }
        }
    }
}

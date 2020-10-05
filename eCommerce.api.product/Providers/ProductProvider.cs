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
    public class ProductProvider : IProductProvider
    {
        private readonly ProductDbContext dbContext;
        private readonly ILogger<ProductProvider> logger;
        private readonly IMapper mapper;

        public ProductProvider(ProductDbContext dbContext,
            ILogger<ProductProvider> logger,IMapper mapper )
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {
            if(!this.dbContext.Products.Any())
            {
                this.dbContext.Products.Add(new db.Product() { Id = 1, Name = "Mouse", Inventory = 100, Price = 15 });
                this.dbContext.Products.Add(new db.Product() { Id = 2, Name = "Keyboard", Inventory = 200, Price = 30 });
                this.dbContext.Products.Add(new db.Product() { Id = 3, Name = "Monitor", Inventory = 300, Price = 45 });
                this.dbContext.Products.Add(new db.Product() { Id = 4, Name = "CPU", Inventory = 400, Price = 60});
                dbContext.SaveChanges();
            }
        }

       

        public async Task<(bool IsSuccess, IEnumerable<models.Product> Products, string errorMessage)> GetProductsAsync()
        {
            try
            {
                var products = await dbContext.Products.ToListAsync();
                if (products != null && products.Any())
                {
                    var result = mapper.Map<IEnumerable<db.Product>, IEnumerable<models.Product>>(products);
                    return (true, result, null);
                }
                return (false, null, "Product not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);

            }
           
        }

        public async Task<(bool IsSuccess, Product Products, string errorMessage)> GetProductAsync(int Id)
        {
            try
            {
                var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == Id);
                if (product != null)
                {
                    var result = mapper.Map<db.Product, models.Product>(product);
                    return (true, result, null);
                }


                return (false,null,"Product not found");


            }
            catch (Exception ex)
            {
                logger?.LogError(ex.Message);
                return (false, null, ex.Message);
            }

            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using eCommerce.api.search.Interfaces;
using eCommerce.api.search.Models;
using Microsoft.Extensions.Logging;

namespace eCommerce.api.search.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<IProductService> logger;
        private readonly IHttpClientFactory httpClient;

        public ProductService( ILogger<IProductService> logger, IHttpClientFactory httpClient  )
        {
            this.logger = logger;
            this.httpClient = httpClient;
        }

        public async Task<(bool IsSuccess, IEnumerable<Product> products, string errorMessage)> GetProductAsync()
        {
            try
            {
                var client =  httpClient.CreateClient("ProductService");
                var response = await client.GetAsync("api/orders");
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var products = JsonSerializer.Deserialize<IEnumerable<Product>>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    return (true, products, null);
                }

                return (false, null, "No product found");


            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }
    }
}

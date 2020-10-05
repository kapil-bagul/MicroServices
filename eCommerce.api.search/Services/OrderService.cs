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
    public class OrderService : IOrderService
    {
        private readonly IOrderService orderService;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<OrderService> logger;

        public OrderService(IHttpClientFactory httpClientFactory, ILogger<OrderService> logger )
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, IEnumerable<Order> orders, string errorMessage)> GetOrderAsync(int customerId)
        {
            try
            {
                var client = httpClientFactory.CreateClient("orderservice");
                var response = await client.GetAsync($"api/orders/{customerId}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var result = JsonSerializer.Deserialize<IEnumerable<Order>>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    return (true, result, null);

                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
           
        }
    }
}

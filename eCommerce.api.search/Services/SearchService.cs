using System;
using eCommerce.api.search.Interfaces;
using System.Threading.Tasks;
using System.Linq;

namespace eCommerce.api.search.Services
{
    public class SearchService : ISearchService
    {
        private readonly IOrderService orderService;
        private readonly IProductService productService;

        public SearchService(IOrderService orderService, IProductService productService )
        {
            this.orderService = orderService;
            this.productService = productService;
        }

        public async Task<(bool IsSuccess, dynamic SearchResult)> SearchAsync(int customerId)
        {
            var orderResult = await orderService.GetOrderAsync(customerId);
            var productResult = await productService.GetProductAsync();


            if (orderResult.IsSuccess)
            {

                foreach (var order in orderResult.orders)
                {
                    foreach (var item in order.Items)
                    {
                        item.ProductName = productResult.products.FirstOrDefault(p => p.Id == item.ProductId).Name;
                    }
                }
                var result = new
                {
                    orders = orderResult.orders
                };

                return (true, result);
            }
            return (false, null);
        }
    }
}

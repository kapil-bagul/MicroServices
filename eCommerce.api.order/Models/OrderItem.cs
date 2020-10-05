using System;
namespace eCommerce.api.order.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public OrderItem()
        {
        }
    }
}

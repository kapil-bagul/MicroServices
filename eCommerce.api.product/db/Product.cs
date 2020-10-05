using System;
namespace eCommerce.api.product.db
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Inventory { get; set; }
        public Product()
        {
        }
    }
}

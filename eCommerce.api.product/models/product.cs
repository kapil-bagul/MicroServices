using System;
namespace eCommerce.api.product.models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Inventory { get; set; }
        public Product()
        {
            

        }
    }
}

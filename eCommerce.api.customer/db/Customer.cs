using System;
namespace eCommerce.api.product.db
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public Customer()
        {
        }
    }
}

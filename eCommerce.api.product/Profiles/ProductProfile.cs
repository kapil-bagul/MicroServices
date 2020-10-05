using System;
namespace eCommerce.api.product.Profiles
{
    public class ProductProfile: AutoMapper.Profile
    {
        public ProductProfile()
        {
            CreateMap<db.Product, models.Product>();
        }
    }
}

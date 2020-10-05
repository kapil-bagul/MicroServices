using System;
namespace eCommerce.api.product.Profiles
{
    public class CustomerProfile : AutoMapper.Profile
    {
        
        public CustomerProfile()
        {
            CreateMap<db.Customer, models.Customer>();
        }
    }
}

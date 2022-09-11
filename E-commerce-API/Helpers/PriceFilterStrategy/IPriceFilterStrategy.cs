using ECommerce.API.Dtos.AppUserDtos.Product;
using ECommerce.API.Dtos.Shared;
using ECommerce.API.Models;

namespace ECommerce.API.Helpers.PriceFilterStrategy
{
    public interface IPriceFilterStrategy
    {
        public IEnumerable<Product> filter(IEnumerable<Product> products, ProductFilter filter);
    }
}

using ECommerce.API.Dtos.AppUserDtos.Product;
using ECommerce.API.Dtos.Shared;
using ECommerce.API.Models;

namespace ECommerce.API.Helpers.PriceFilterStrategy
{
    public interface IProductFilterContext
    {
        IEnumerable<Product> FilterProductByPrice(IEnumerable<Product> products, ProductFilter filter);

        IEnumerable<Product> FilterProductByStars(IEnumerable<Product> products, int? stars);
    }
}

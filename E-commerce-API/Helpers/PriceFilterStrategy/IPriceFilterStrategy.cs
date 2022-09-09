using ECommerce.API.Dtos.AppUserDtos.Product;
using ECommerce.API.Dtos.Shared;

namespace ECommerce.API.Helpers.PriceFilterStrategy
{
    public interface IPriceFilterStrategy
    {
        public IEnumerable<AppUserProductDto> filter(IEnumerable<AppUserProductDto> products, ProductFilter filter);
    }
}

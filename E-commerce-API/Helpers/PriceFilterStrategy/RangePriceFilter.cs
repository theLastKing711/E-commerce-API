using ECommerce.API.Dtos.AppUserDtos.Product;
using ECommerce.API.Dtos.Shared;

namespace ECommerce.API.Helpers.PriceFilterStrategy
{
    public class RangePriceFilter : IPriceFilterStrategy
    {
        public IEnumerable<AppUserProductDto> filter(IEnumerable<AppUserProductDto> products, ProductFilter filter)
        {
            return products.Where(product => this.IsGreaterThanOrEqual(filter.EndValue, product.Price) && this.IsLessThanOrEqual(product.Price, filter.EndValue));
        }

        private bool IsLessThanOrEqual(decimal firstValue, decimal secondValue)
        {
            return firstValue <= secondValue;
        }

        private bool IsGreaterThanOrEqual(decimal firstValue, decimal secondValue)
        {
            return firstValue >= secondValue;
        }
    }
}

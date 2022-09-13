using ECommerce.API.Dtos.AppUserDtos.Product;
using ECommerce.API.Dtos.Shared;
using ECommerce.API.Models;

namespace ECommerce.API.Helpers.PriceFilterStrategy
{
    public class RangePriceFilter : IPriceFilterStrategy
    {
        public IEnumerable<Product> filter(IEnumerable<Product> products, ProductFilter filter)
        {
            return products.Where(product => this.IsGreaterThanOrEqual(product.Price, filter.StartValue) && this.IsLessThanOrEqual(product.Price, filter.EndValue));
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

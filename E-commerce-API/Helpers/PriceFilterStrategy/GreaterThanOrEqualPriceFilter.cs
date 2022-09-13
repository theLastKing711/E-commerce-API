using ECommerce.API.Dtos.Shared;
using ECommerce.API.Models;

namespace ECommerce.API.Helpers.PriceFilterStrategy
{
    public class GreaterThanOrEqualPriceFilter : IPriceFilterStrategy
    {
        public IEnumerable<Product> filter(IEnumerable<Product> products, ProductFilter filter)
        {
            return products.Where(product => this.IsGreaterThanOrEqual(product.Price, filter.StartValue));
        }

        private bool IsGreaterThanOrEqual(decimal firstValue, decimal secondValue)
        {
            return firstValue >= secondValue;
        }
    }
}

using ECommerce.API.Dtos.AppUserDtos.Product;
using ECommerce.API.Dtos.Shared;
using ECommerce.API.Models;

namespace ECommerce.API.Helpers.PriceFilterStrategy
{
    public class GreaterThanPriceFilter : IPriceFilterStrategy
    {
        public IEnumerable<Product> filter(IEnumerable<Product> products, ProductFilter filter)
        {
            return products.Where(product => IsGreaterThan(filter.StartValue, product.Price));
        }

        private bool IsGreaterThan(decimal firstValue, decimal secondValue)
        {
            return firstValue > secondValue;
        }
    }
}

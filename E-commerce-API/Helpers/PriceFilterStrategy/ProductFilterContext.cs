using ECommerce.API.Dtos.AppUserDtos.Product;
using ECommerce.API.Dtos.Shared;
using ECommerce.API.Models;

namespace ECommerce.API.Helpers.PriceFilterStrategy
{
    public class ProductFilterContext : IProductFilterContext
    {

        public IServiceProvider _serviceProvider;

        public ProductFilterContext(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        private IPriceFilterStrategy GetPriceFilterStrategy(SortType key)
        {

            var priceFilterServices = _serviceProvider.GetServices<IPriceFilterStrategy>();

            IPriceFilterStrategy priceFilterStrategy;

            switch (key)
            {
                case (SortType.LessThan):
                    priceFilterStrategy = priceFilterServices.FirstOrDefault(x => x.GetType() == typeof(LessThanPriceFilter))!;
                    break;
                case (SortType.Range):
                    priceFilterStrategy = priceFilterServices.FirstOrDefault(x => x.GetType() == typeof(RangePriceFilter))!;
                    break;
                case (SortType.EqualOrGreaterThan):
                    priceFilterStrategy = priceFilterServices.FirstOrDefault(x => x.GetType() == typeof(GreaterThanPriceFilter))!;
                    break;
                default:
                    priceFilterStrategy = null;
                    break;
            }

            return priceFilterStrategy;
        }

        public IEnumerable<Product> FilterProductByPrice(IEnumerable<Product> products, ProductFilter filter)
        {

            IPriceFilterStrategy priceFilterStrategy = this.GetPriceFilterStrategy(filter.SortType);

            if(priceFilterStrategy == null)
            {
                return products;
            }

            return priceFilterStrategy.filter(products, filter);

        }

        public  IEnumerable<Product> FilterProductByStars(IEnumerable<Product> products, int? stars)
        {

            if(stars == null)
            {
                return products;
            }

            var filterdProductsByStars =  products
                                                  .Where(x => x.Reviews.Average(x => x.Rating) > stars);


            return filterdProductsByStars;
        }

    }
}

using ECommerce.API.Dtos.Category;
using ECommerce.API.Dtos.Product;

namespace ECommerce.API.Dtos.Stats
{
    public class StatsDto
    {
        public IEnumerable<YearlySalesDto> YearlySalesDto;

        public IEnumerable<TopSellerProductDto> TopSellerProductsDto;

        public IEnumerable<TopSellerCategoryDto> TopSellerCategoryDto;

    }
}

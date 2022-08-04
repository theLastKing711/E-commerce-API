using ECommerce.API.Dtos.Product;
using ECommerce.API.Models;

namespace ECommerce.API.Dtos.Category
{
    public class CategoryDto : BaseDto
    {
        public string Name { get; set; }

        public IEnumerable<ProductDto> ProductsDto { get; set; }
    }
}

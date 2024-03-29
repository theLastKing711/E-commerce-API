using ECommerce.API.Dtos.Product;
using ECommerce.API.Models;

namespace ECommerce.API.Dtos.Category
{
    public class CategoryWithProductsDto : BaseDto
    {

        public CategoryDto CategoryDto { get; set; }

        public string Name { get; set; }

        public IEnumerable<ProductDto> Products { get; set; }

    }
}

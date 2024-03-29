using ECommerce.API.Dtos.Category;
using ECommerce.API.Dtos.Discount;
using ECommerce.API.Dtos.Review;
using ECommerce.API.Models;

namespace ECommerce.API.Dtos.Product
{
    public class ProductDto : ProductBase
    {

        public CategoryDto Category { get; set; }

        public string Path { get; set; }

        public string? ThumbImagePath { get; set; }

        public string? FullImagePath { get; set; }

        public IEnumerable<ReviewDto> Reviews { get; set; }

        public IEnumerable<DiscountDto> Discounts { get; set; }
    }
}

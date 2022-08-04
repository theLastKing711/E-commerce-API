using ECommerce.API.Dtos.Product;

namespace ECommerce.API.Dtos.Review
{
    public class ReviewDto : ReviewBaseDto
    {
        public CustomerDto Customer { get; set; }
        public ProductDto Product { get; set; }


    }
}

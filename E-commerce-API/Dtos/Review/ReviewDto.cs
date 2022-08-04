using ECommerce.API.Dtos.Product;
using ECommerce.API.Models.Identity;

namespace ECommerce.API.Dtos.Review
{
    public class ReviewDto : ReviewBaseDto
    {
        public CustomerDto Customer { get; set; }
        public ProductDto Product { get; set; }

        public AppUser AppUser { get; set; }

        public int AppUserId { get; set; }

    }
}

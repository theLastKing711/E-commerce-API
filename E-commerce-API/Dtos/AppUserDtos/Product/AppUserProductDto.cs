using ECommerce.API.Dtos.Product;

namespace ECommerce.API.Dtos.AppUserDtos.Product
{
    public class AppUserProductDto : ProductBase
    {

        public int DiscountValue { get; set; }

        public decimal PriceAfterDiscount { get; set; }

        public decimal Rating { get; set; }

        public int TotalReviews { get; set; }

        public string Path { get; set; }

        public string? ThumbImagePath { get; set; }

        public string? FullImagePath { get; set; }



        public IEnumerable<AppUserProductDetails> Details { get; set; }

    }
}

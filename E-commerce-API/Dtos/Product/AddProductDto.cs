namespace ECommerce.API.Dtos.Product
{
    public class AddProductDto
    {

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool IsBestSeller { get; set; } = false;

        public IFormFile? Image { get; set; }

        public IFormFile? ThumbImage { get; set; }

    }
}

namespace ECommerce.API.Dtos
{
    public class AddProductDto : BaseDto
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public IFormFile? Image { get; set; }
    }
}

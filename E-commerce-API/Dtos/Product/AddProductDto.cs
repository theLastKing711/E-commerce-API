namespace ECommerce.API.Dtos.Product
{
    public class AddProductDto : ProductBase
    {
        public IFormFile? Image { get; set; }
    }
}

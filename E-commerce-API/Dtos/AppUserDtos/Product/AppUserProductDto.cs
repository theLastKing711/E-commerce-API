using ECommerce.API.Dtos.Product;

namespace ECommerce.API.Dtos.AppUserDtos.Product
{
    public class AppUserProductDto : ProductBase
    {
        public decimal Rating { get; set; }

        public string Path { get; set; }
    }
}

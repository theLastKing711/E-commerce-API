

namespace ECommerce.API.Dtos.Product
{
    public class ProductItemDto
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public String Path { get; set; }

        public string ThumbPath { get; set; }

    }
}

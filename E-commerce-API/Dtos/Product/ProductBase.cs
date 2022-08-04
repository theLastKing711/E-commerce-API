using ECommerce.API.Dtos.Category;
using ECommerce.API.Models;

namespace ECommerce.API.Dtos.Product
{
    public class ProductBase : BaseEntity
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool IsPopular { get; set; } = false;

    }
}

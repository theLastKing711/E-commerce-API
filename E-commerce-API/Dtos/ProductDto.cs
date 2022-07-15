using ECommerce.API.Dtos;

namespace ECommerce.API.Models
{
  public class ProductDto : BaseEntity
  {
    public int CategoryId { get; set; }
    public CategoryDto? CategoryDto { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public string Path { get; set; }
  }
}

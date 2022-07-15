using ECommerce.API.Models;

namespace ECommerce.API.Dtos
{
  public class CategoryDto : BaseDto
  {
    public string Name { get; set; }

    public IEnumerable<ProductDto> ProductsDto { get; set; }
  }
}

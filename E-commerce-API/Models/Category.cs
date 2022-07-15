using ECommerce.API.Models;

namespace ECommerce.API.Models
{
  public class Category : BaseEntity
  {
    public string Name { get; set; }

    public IEnumerable<Product> Products { get; set; }

  }
}

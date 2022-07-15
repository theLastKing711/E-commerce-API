namespace ECommerce.API.Models
{
  public class Product : BaseEntity
  {

    public int CategoryId { get; set; }

    public Category Category { get; set; }


    public string Name { get; set; }

    public decimal Price { get; set; }

    public string Path { get; set; }

  }
}

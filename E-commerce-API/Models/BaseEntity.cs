namespace ECommerce.API.Models
{
  public class BaseEntity
  {
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
  }
}

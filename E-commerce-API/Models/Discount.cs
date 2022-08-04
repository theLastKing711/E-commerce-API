using ECommerce.API.Models;

public class Discount : BaseEntity
{

    public Product Product { get; set; }

    public int ProductId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int Value { get; set; }

}
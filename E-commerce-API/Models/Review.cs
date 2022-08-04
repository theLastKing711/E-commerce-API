namespace ECommerce.API.Models
{
    public class Review : BaseEntity
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public decimal Rating { get; set; }

        public string Body { get; set; }
    }
}

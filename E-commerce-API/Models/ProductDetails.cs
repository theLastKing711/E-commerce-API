namespace ECommerce.API.Models
{
    public class ProductDetails : BaseEntity
    {

        public Product Product { get; set; }

        public int ProductId { get; set; }

        public string Text { get; set; }

    }
}

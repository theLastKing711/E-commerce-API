namespace ECommerce.API.Models
{
    public class Product : BaseEntity
    {

        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Path { get; set; }

        public string? ThumbImagePath { get; set; }

        public string? FullImagePath { get; set; }

        public bool IsBestSeller { get; set; } = false;

        public IEnumerable<InvoiceDetails> InvoicesDetails { get; set; }

        public IEnumerable<Review> Reviews { get; set; }

        public IEnumerable<Discount> Discounts { get; set; }


        public IEnumerable<ProductDetails> Details { get; set; }


    }
}

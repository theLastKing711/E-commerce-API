using ECommerce.API.Models;

namespace ECommerce.API.Models
{
    public class InvoiceDetails : BaseEntity
    {

        // public Invoice Invoice { get; set; }

        public int InvoiceId { get; set; }

        public Product Product { get; set; }

        public int ProductId { get; set; }

        public int ProductQuantity { get; set; }

    }
}

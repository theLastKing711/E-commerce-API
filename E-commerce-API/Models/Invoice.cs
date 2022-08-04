using ECommerce.API.Models;

namespace ECommerce.API.Models
{
    public class Invoice : BaseEntity
    {
        public IEnumerable<InvoiceDetails> InvoicesDetails { get; set; }
    }
}

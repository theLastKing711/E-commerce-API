using ECommerce.API.Dtos.InvoiceDetails;
using ECommerce.API.Models;

namespace ECommerce.API.Dtos.Invoice
{
    public class InvoiceDto : BaseDto
    {
        public IEnumerable<InvoiceDetailsDto> InvoicesDetails { get; set; }

        public int AppUserId { get; set; }

        public decimal Total { get; set; }
    }
}

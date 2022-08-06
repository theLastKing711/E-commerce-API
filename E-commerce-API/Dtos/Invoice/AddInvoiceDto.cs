using ECommerce.API.Dtos.InvoiceDetails;
using ECommerce.API.Models;

namespace ECommerce.API.Dtos.Invoice
{
    public class AddInvoiceDto
    {   
        public int AppUserId { get; set; }

        public IEnumerable<AddInvoiceDetailsDto> InvoicesDetails { get; set; }
    }
}

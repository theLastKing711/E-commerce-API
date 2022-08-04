using ECommerce.API.Dtos.InvoiceDetails;
using ECommerce.API.Models;

namespace ECommerce.API.Dtos.Invoice
{
    public class AddInvoiceDto
    {
        public IEnumerable<AddInvoiceDetailsDto> InvoicesDetails { get; set; }
    }
}

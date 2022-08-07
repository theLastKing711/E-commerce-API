using ECommerce.API.Models;

namespace ECommerce.API.Dtos.InvoiceDetails
{
    public class AddInvoiceDetailsDto
    {
        public int ProductId { get; set; }

        public int ProductQuantity { get; set; }
    }
}

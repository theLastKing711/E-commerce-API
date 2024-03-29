using ECommerce.API.Dtos.Invoice;
using ECommerce.API.Dtos.Product;
using ECommerce.API.Models;

namespace ECommerce.API.Dtos.InvoiceDetails
{
    public class InvoiceDetailsDto : BaseDto
    {
        public int InvoiceId { get; set; }

        public ProductDto Product { get; set; }

        public int ProductId { get; set; }

        public int ProductQuantity { get; set; }
    }
}

using ECommerce.API.Dtos.Identity.AppUser;
using ECommerce.API.Dtos.InvoiceDetails;
using ECommerce.API.Dtos.Product;

namespace ECommerce.API.Dtos.Invoice
{
    public class InventoryDto
    {

        public int ProductId { get; set; }

        public ProductDto ProductDto { get; set; }

        public int Quantity { get; set; }

        public int CurrentAmount { get; set; }

    }
}

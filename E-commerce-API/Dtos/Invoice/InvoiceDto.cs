using ECommerce.API.Dtos.Identity.AppUser;
using ECommerce.API.Dtos.InvoiceDetails;

namespace ECommerce.API.Dtos.Invoice
{
    public class InvoiceDto : BaseDto
    {
        public IEnumerable<InvoiceDetailsDto> InvoicesDetails { get; set; }

        public AppUserDto AppUser { get; set; }

        public int AppUserId { get; set; }

        public decimal Total { get; set; }
    }
}

using ECommerce.API.Models;
using ECommerce.API.Models.Identity;

namespace ECommerce.API.Models
{
    public class Invoice : BaseEntity
    {
        
        public IEnumerable<InvoiceDetails> InvoicesDetails { get; set; }

        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }

    }
}

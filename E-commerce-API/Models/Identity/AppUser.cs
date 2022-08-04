using Microsoft.AspNetCore.Identity;

namespace ECommerce.API.Models.Identity
{
    public class AppUser : IdentityUser
    {
        public IEnumerable<Invoice> Invoices { get; set; }

        public IEnumerable<Review> Reviews { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace ECommerce.API.Models.Identity
{
    public class AppUser : IdentityUser<int>
    {

        public IEnumerable<Invoice> Invoices { get; set; }

        public IEnumerable<Review> Reviews { get; set; }



        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string? ImagePath { get; set; }


    }
}

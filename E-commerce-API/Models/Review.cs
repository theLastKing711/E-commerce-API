using ECommerce.API.Models.Identity;

namespace ECommerce.API.Models
{
    public class Review : BaseEntity
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }

        public AppUser AppUser{ get; set; }

        public int AppUserId { get; set; }

        public decimal Rating { get; set; }

        public string Body { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.Dtos.Identity.AppUser
{
    public class BaseAppUserDto
    {
        public int Id { set; get; }

        public string Username { get; set; }

        public string Email { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.Dtos.Identity.AppUser
{
    public class AddAppUserDto : BaseAppUserDto
    {
        public string? Password { get; set; }

        public IFormFile Image { get; set; }
    }
}

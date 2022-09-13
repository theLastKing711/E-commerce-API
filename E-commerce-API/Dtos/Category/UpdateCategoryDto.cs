using ECommerce.API.Models;

namespace ECommerce.API.Dtos.Category
{
    public class UpdateCategoryDto : CategoryBase
    {
        public int Id { get; set; }

        public IFormFile Image { get; set; }
    }
}

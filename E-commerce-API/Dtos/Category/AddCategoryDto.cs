using ECommerce.API.Models;

namespace ECommerce.API.Dtos.Category
{
    public class AddCategoryDto : BaseDto
    {
        public string Name { get; set; }

        public IFormFile Image { get; set; }
    }
}

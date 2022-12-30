using ECommerce.API.Models;

namespace ECommerce.API.Dtos.Category
{
    public class AddCategoryDto : CategoryBase
    {
        public IFormFile? Image { get; set; }
    }
}

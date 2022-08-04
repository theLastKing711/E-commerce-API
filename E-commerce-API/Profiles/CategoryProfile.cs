using AutoMapper;
using ECommerce.API.Dtos.Category;
using ECommerce.API.Models;

namespace ECommerce.API.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, AddCategoryDto>();
            CreateMap<AddCategoryDto, Category>();
            CreateMap<Category, CategoryItemDto>();
        }
    }
}

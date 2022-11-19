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
            CreateMap<Category, CategoryDto>()
            .ForMember(
                dest => dest.Path,
                opt => opt.MapFrom(x => $"https://e-commerce-api1.herokuapp.com/api/images/{x.Path}")
                // opt => opt.MapFrom(x => $"https://localhost:7267/images/{x.Path}")
            );

            CreateMap<Category, AddCategoryDto>();
            CreateMap<AddCategoryDto, Category>();
            CreateMap<Category, CategoryItemDto>();


        }
    }
}

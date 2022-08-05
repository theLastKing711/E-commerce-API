using AutoMapper;
using ECommerce.API.Dtos.Identity;
using ECommerce.API.Dtos.Identity.AppUser;
using ECommerce.API.Models;
using ECommerce.API.Models.Identity;

namespace ECommerce.API.Profiles
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUserDto, AppUser>();
            CreateMap<AppUser, AppUserDto>();
            CreateMap<AddAppUserDto, AppUser>().ForMember(
                dest => dest.ImagePath,
                opt => opt.MapFrom(src => $"{src.Image.FileName}")
            );
            CreateMap<AppUser, AddAppUserDto>();
        }
    }
}

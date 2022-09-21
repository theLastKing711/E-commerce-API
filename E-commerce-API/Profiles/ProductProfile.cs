using AutoMapper;
using ECommerce.API.Dtos.AppUserDtos.Product;
using ECommerce.API.Dtos.Product;
using ECommerce.API.Models;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductDto, Product>();
        CreateMap<Product, ProductDto>();
        CreateMap<Product, AddProductDto>();
        CreateMap<AddProductDto, Product>()
            .ForMember(
                dest => dest.Path,
                opt => opt.MapFrom(src => $"{src.Image.FileName}")
            );
        CreateMap<Product, ProductItemDto>();

        CreateMap<Product, AppUserProductDto>()
            .ForMember(
                dest => dest.Rating,
                opt => opt.MapFrom(x => x.Reviews.Any() ? x.Reviews.Average(x => x.Rating) : 0)
            )
            .ForMember(
                dest => dest.TotalReviews,
                opt => opt.MapFrom(x => x.Reviews.Any() ? x.Reviews.Count() : 0)
            )
            .ForMember(
                dest => dest.Path,
                opt => opt.MapFrom(x => $"https://localhost:7267/images/{x.Path}")
            )
            .ForMember(
                dest => dest.ThumbImagePath,
                opt => opt.MapFrom(x => $"https://localhost:7267/images/{x.ThumbImagePath}")
            )
            .ForMember(
                dest => dest.FullImagePath,
                opt => opt.MapFrom(x => $"https://localhost:7267/images/{x.FullImagePath}")
            )
            ;

    }

}
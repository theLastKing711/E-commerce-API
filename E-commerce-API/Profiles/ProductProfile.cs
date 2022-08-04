using AutoMapper;
using ECommerce.API.Dtos;
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
    }
}
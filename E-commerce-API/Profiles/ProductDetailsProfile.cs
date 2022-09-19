using AutoMapper;
using ECommerce.API.Dtos.AppUserDtos.Product;
using ECommerce.API.Models;

public class ProductDetailsProfile : Profile
{
    public ProductDetailsProfile()
    {
        CreateMap<ProductDetails, AppUserProductDetails>();
    }

}
using AutoMapper;
using ECommerce.API.Dtos.Discount;

public class DiscountProfile : Profile
{
    public DiscountProfile()
    {
        CreateMap<DiscountDto, Discount>();
        CreateMap<Discount, DiscountDto>();
        CreateMap<Discount, AddDiscountDto>();
        CreateMap<AddDiscountDto, Discount>();
    }
}
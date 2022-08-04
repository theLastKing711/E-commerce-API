using AutoMapper;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerDto, Customer>();
        CreateMap<Customer, CustomerDto>();
        CreateMap<Customer, AddCustomerDto>();
        CreateMap<AddCustomerDto, Customer>()
            .ForMember(
                dest => dest.ImagePath,
                opt => opt.MapFrom(src => $"{src.Image.FileName}")
            );

    }
}
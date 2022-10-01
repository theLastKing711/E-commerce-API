using AutoMapper;
using ECommerce.API.Dtos.Discount;
using ECommerce.API.Dtos.Invoice;
using ECommerce.API.Models;

public class InventoryProfile : Profile
{
    public InventoryProfile()
    {
        CreateMap<InventoryDto, Inventory>();
    }
}
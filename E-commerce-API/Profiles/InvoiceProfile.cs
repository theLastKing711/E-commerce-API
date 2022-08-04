using AutoMapper;
using ECommerce.API.Dtos.Invoice;
using ECommerce.API.Dtos.InvoiceDetails;
using ECommerce.API.Models;

public class InvoiceProfile : Profile
{
    public InvoiceProfile()
    {
        CreateMap<InvoiceDto, Invoice>();
        CreateMap<Invoice, InvoiceDto>();

        CreateMap<Invoice, AddInvoiceDto>();
        CreateMap<AddInvoiceDto, Invoice>();
        CreateMap<InvoiceDetails, InvoiceDetailsDto>();
        CreateMap<InvoiceDetailsDto, InvoiceDetails>();
    }
}
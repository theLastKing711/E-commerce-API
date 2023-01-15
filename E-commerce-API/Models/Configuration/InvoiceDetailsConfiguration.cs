using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class InvoiceDetailsConfiguration : IEntityTypeConfiguration<InvoiceDetailsConfiguration>
{
    public void Configure(EntityTypeBuilder<InvoiceDetailsConfiguration> builder)
    {
        builder.HasData(
            new InvoiceDetails
            {
                Id = 1,
                InvoiceId = 1,
                ProductQuantity = 25
            },
            new InvoiceDetails
            {
                Id = 2,
                InvoiceId = 1,
                ProductQuantity = 15
            },
            new InvoiceDetails
            {
                Id = 3,
                InvoiceId = 2,
                ProductQuantity = 100
            },
            new InvoiceDetails
            {
                Id = 4,
                InvoiceId = 3,
                ProductQuantity = 40,
            }
        );
    }
}
using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class InvoiceDetailsConfiguration : IEntityTypeConfiguration<InvoiceDetails>
{
    public void Configure(EntityTypeBuilder<InvoiceDetails> builder)
    {
        builder.HasData(
            new InvoiceDetails
            {
                Id = 1,
                InvoiceId = 1,
                ProductId = 1,
                ProductQuantity = 25
            },
            new InvoiceDetails
            {
                Id = 2,
                InvoiceId = 1,
                ProductId = 2,
                ProductQuantity = 15
            },
            new InvoiceDetails
            {
                Id = 3,
                InvoiceId = 2,
                ProductId = 2,
                ProductQuantity = 100
            },
            new InvoiceDetails
            {
                Id = 4,
                InvoiceId = 3,
                ProductId = 5,
                ProductQuantity = 40,
            }
        );
    }
}
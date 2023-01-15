using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.HasData(
            new Invoice
            {
                Id = 1,
                AppUserId = 100,
            },
            new Invoice
            {
                Id = 2,
                AppUserId = 101
            },
            new Invoice
            {
                Id = 3,
                AppUserId = 101
            }
        );
    }
}
using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {

        builder.HasData(
            new Discount
            {
                Id = 1,
                ProductId = 1,
                Value = 20,
                StartDate = new DateTime(2020, 5, 12),
                EndDate = new DateTime(2021, 5, 20)
            },
            new Discount
            {
                Id = 2,
                ProductId = 1,
                Value = 30,
                StartDate = new DateTime(2022, 5, 12),
                EndDate = new DateTime(2023, 5, 20),
            },
            new Discount
            {
                Id = 3,
                ProductId = 2,
                Value = 40,
                StartDate = new DateTime(2023, 5, 12),
                EndDate = new DateTime(2024, 5, 20)
            },
            new Discount
            {
                Id = 4,
                ProductId = 2,
                Value = 50,
                StartDate = new DateTime(2020, 3, 12),
                EndDate = new DateTime(2026, 1, 20)
            }
        );

    }
}
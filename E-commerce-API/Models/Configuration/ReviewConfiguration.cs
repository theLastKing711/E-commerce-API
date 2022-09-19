using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {

        builder.HasData(
            new Review
            {
                Id = 1,
                ProductId = 1,
                AppUserId = 100,
                Body = "Well Done!",
                Rating = 4

            },
            new Review
            {
                Id = 2,
                ProductId = 1,
                AppUserId = 101,
                Body = "Well Done!",
                Rating = 5
            },
            new Review
            {
                Id = 3,
                ProductId = 1,
                AppUserId = 102,
                Body = "Well Done!",
                Rating = 1
            },
            new Review
            {
                Id = 4,
                ProductId = 1,
                AppUserId = 104,
                Body = "Well Done!",
                Rating = 5
            },
            new Review
            {
                Id = 5,
                ProductId = 2,
                AppUserId = 104,
                Body = "Well Done!",
                Rating = 2
            },
            new Review
            {
                Id = 6,
                ProductId = 2,
                AppUserId = 103,
                Body = "Well Done!",
                Rating = 3
            },
            new Review
            {
                Id = 7,
                ProductId = 2,
                AppUserId = 104,
                Body = "Well Done!",
                Rating = 5
            },
            new Review
            {
                Id = 8,
                ProductId = 3,
                AppUserId = 104,
                Body = "Well Done!",
                Rating = 1
            },
            new Review
            {
                Id = 9,
                ProductId = 4,
                AppUserId = 102,
                Body = "Well Done!",
                Rating = 4
            },
            new Review
            {
                Id = 10,
                ProductId = 4,
                AppUserId = 102,
                Body = "Well Done!",
                Rating = 3
            },
            new Review
            {
                Id = 11,
                ProductId = 5,
                AppUserId = 104,
                Body = "Well Done!",
                Rating = 5
            },
            new Review
            {
                Id = 12,
                ProductId = 6,
                AppUserId = 104,
                Body = "Well Done!",
                Rating = 5
            }
        );

    }
}
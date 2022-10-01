using ECommerce.API.Dtos.Identity;
using ECommerce.API.Models;
using ECommerce.API.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {

        builder.HasData(
            new Inventory
            {
                Id = 1,
                ProductId = 1,
                Quantity = 40,
                CurrentAmount = 25
            },
            new Inventory
            {
                Id = 2,
                ProductId = 1,
                Quantity = 40,
                CurrentAmount = 40
            },
            new Inventory
            {
                Id = 3,
                ProductId = 3,
                Quantity = 10,
                CurrentAmount = 0
            },
            new Inventory
            {
                Id = 4,
                ProductId = 3,
                Quantity = 10,
                CurrentAmount = 10
            },
            new Inventory
            {
                Id = 5,
                ProductId = 4,
                Quantity = 25,
                CurrentAmount = 0
            },
            new Inventory
            {
                Id = 6,
                ProductId = 5,
                Quantity = 40,
                CurrentAmount = 0
            },
            new Inventory
            {
                Id = 7,
                ProductId = 6,
                Quantity = 15,
                CurrentAmount = 5
            },
            new Inventory
            {
                Id = 8,
                ProductId = 7,
                Quantity = 30,
                CurrentAmount = 15
            },
            new Inventory
            {
                Id = 9,
                ProductId = 8,
                Quantity = 25,
                CurrentAmount = 25
            }
        );
    }
}
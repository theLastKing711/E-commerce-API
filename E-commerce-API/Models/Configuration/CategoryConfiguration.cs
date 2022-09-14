using ECommerce.API.Dtos.Identity;
using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {

        builder.HasData(
            new Category
            {
                Id = 1,
                Name = "Electronices",
                Path = "category_Fuji_Dash_Electronics_1x._SY304_CB432774322_.jpg"
            },
            new Category
            {
                Id = 2,
                Name = "Computers",
                Path = "category-Fuji_Dash_PC_1x._SY304_CB431800965_.jpg"
            },
            new Category
            {
                Id = 3,
                Name = "Games",
                Path = "category-games_Fuji_Desktop_Dash_Kindle_1x._SY304_CB639752818_.jpg",
            },
             new Category
             {
                 Id = 4,
                 Name = "Pets",
                 Path = "category-pets_Fuji_Dash_Pets_1X._SY304_CB639746743_.jpg",
             }
        );

    }
}
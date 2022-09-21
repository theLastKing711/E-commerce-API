using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {

        builder.HasData(
            new Product
            {
                Id = 1,
                Name = "Sceptre 24 Professional Thin 75Hz 1080p LED Monitor 2x HDMI VGA Build-in Speakers, Machine Black (E248W-19203R Series)",
                CategoryId = 1,
                IsBestSeller = true,
                Price = 200,
                Path = "electronics-laptop_71rXSVqET9L._AC_UL320_.jpg",
                ThumbImagePath = "laptop-thumb_71qid7QFWJL._SX3000_.jpg",
                FullImagePath = "laptop-full_71rXSVqET9L._AC_SL1257_.jpg"
            },
            new Product
            {
                Id = 2,
                Name = "Mobile",
                CategoryId = 1,
                IsBestSeller = true,
                Price = 100,
                Path = "electronics-mobile_81AeiqxHkwL._AC_UL320_.jpg",
                ThumbImagePath = "mobile-thumb_81AeiqxHkwL._AC_SY679_.jpg",
                FullImagePath = "mobile-full_81AeiqxHkwL._AC_SL1500_.jpg"
            },
            new Product
            {
                Id = 3,
                Name = "Printer",
                CategoryId = 1,
                IsBestSeller = true,
                Price = 400,
                Path = "electronics-printer_61UdeL7aO-L._AC_UL320_.jpg",
                ThumbImagePath = "printer-thumb_61UdeL7aO-L._AC_SX466_.jpg",
                FullImagePath = "printer-full_61UdeL7aO-L._AC_SL1500_.jpg"
            },
             new Product
             {
                 Id = 4,
                 Name = "EarPods",
                 CategoryId = 1,
                 IsBestSeller = true,
                 Price = 15,
                 Path = "electronices-headphones_7120GgUKj3L._AC_UL320_.jpg",
                 ThumbImagePath = "earpod-thumb_7120GgUKj3L._AC_SX522_.jpg",
                 FullImagePath = "earpod_full-7120GgUKj3L._AC_SL1500_.jpg"
             },
             new Product
             {
                 Id = 5,
                 Name = "Batteries",
                 CategoryId = 1,
                 IsBestSeller = true,
                 Price = 5,
                 Path = "electronics-batteries_81ZnAYiX5sL._AC_UL320_.jpg",
                 ThumbImagePath = "batteries-thumb_81ZnAYiX5sL._AC_SX679_.jpg",
                 FullImagePath = "batteries-full_81ZnAYiX5sL._AC_SL1500_.jpg"
             },
             new Product
             {
                 Id = 6,
                 Name = "Pen",
                 CategoryId = 1,
                 IsBestSeller = true,
                 Price = 250,
                 Path = "electronics-pen_21SPDoiRuGL._AC_UL320_.jpg",
                 ThumbImagePath = "pen-thumb_21l795GXZkL._AC_SY500_.jpg",
                 FullImagePath = "pen-full_21l795GXZkL._AC_SL1024_.jpg"
             },
            new Product
            {
                Id = 7,
                Name = "Usb",
                CategoryId = 1,
                IsBestSeller = false,
                Price = 25,
                Path = "electronics-usb_71wrIZujPIL._AC_UL320_.jpg",
                ThumbImagePath = "usb-thumb_71wrIZujPIL._AC_SX466_.jpg",
                FullImagePath = "usb-full_71wrIZujPIL._AC_SL1500_.jpg"
            },
            new Product
            {
                Id = 8,
                CategoryId = 2,
                Name = "Player",
                IsBestSeller = true,
                Price = 350,
                Path = "computers-player_71E4InwfcPL._AC_UL320_.jpg",
                ThumbImagePath = "player-thumb_71E4InwfcPL._AC_SX466_.jpg",
                FullImagePath = "player-full_71E4InwfcPL._AC_SL1500_.jpg"
            },
            new Product
            {
                Id = 9,
                CategoryId = 3,
                Name = "Computer",
                IsBestSeller = true,
                Price = 25,
                Path = "games-controller_61X3uV04ztL._AC_UL320_.jpg",
                ThumbImagePath = "controller-thumb_61X3uV04ztL._SX522_.jpg",
                FullImagePath = "controller-full_61X3uV04ztL._SL1500_.jpg"
            },
            new Product
            {
                Id = 10,
                CategoryId = 3,
                Name = "Computer",
                IsBestSeller = false,
                Price = 90,
                Path = "games-vr_61tE7IcuLmL._AC_UL320_.jpg",
                ThumbImagePath = "vr-thumb_61tE7IcuLmL._SX522_.jpg",
                FullImagePath = "vr-full_61tE7IcuLmL._SL1500_.jpg"
            },
            new Product
            {
                Id = 11,
                CategoryId = 3,
                Name = "Computer",
                IsBestSeller = true,
                Price = 150,
                Path = "games-xbox_61JGKhqxHxL._AC_UL320_.jpg",
                ThumbImagePath = "xbox-thumb_61JGKhqxHxL._SX522_.jpg",
                FullImagePath = "xbox-full_61JGKhqxHxL._SL1500_.jpg"
            }
            // new Product
            // {
            //     Id = 12,
            //     CategoryId = 4,
            //     Name = "Cat",
            //     IsBestSeller = false,
            //     Price = 400,
            //     Path = "pets-cat_61ng2AAFZRL._AC_UL320_.jpg",
            // }
        );
    }
}
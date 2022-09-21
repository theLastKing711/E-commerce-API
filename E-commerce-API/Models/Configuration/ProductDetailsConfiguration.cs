using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProductDetailsConfiguration : IEntityTypeConfiguration<ProductDetails>
{
    public void Configure(EntityTypeBuilder<ProductDetails> builder)
    {

        builder.HasData(
           new ProductDetails
           {
               Id = 1,
               ProductId = 1,
               Text = "24 Ultra slim profile "
           },
           new ProductDetails
           {
               Id = 2,
               ProductId = 1,
               Text = "Slim bezel with thin chassis. Power Range (V, A, Hz)- AC-DC Adapter Input 100 – 240 VAC, 50/60 Hz, 1.0A (Max.) Output - 12V DC, 2.5A. Power Consumption (Typical)- 25.4W. Neck/Stand Detachable: Yes "
           },
           new ProductDetails
           {
               Id = 3,
               ProductId = 1,
               Text = "2 x HDMI Ports (convertible to DVI).Contrast Ratio:1000 : 1"
           },
           new ProductDetails
           {
               Id = 4,
               ProductId = 1,
               Text = "VESA wall mount ready. HDMI Input Signal Support - 1920 x 1080 @ 75Hz, 1080/60p, 1080/60i, 720p, 480p, 480i, Built-in Speakers - 2 x 2W 8 Ohm.Mounting type: VESA Hole Pattern 100mm x 100mm"
           },

            new ProductDetails
            {
                Id = 5,
                ProductId = 2,
                Text = "24 Ultra slim profile "
            },
           new ProductDetails
           {
               Id = 6,
               ProductId = 2,
               Text = "Slim bezel with thin chassis. Power Range (V, A, Hz)- AC-DC Adapter Input 100 – 240 VAC, 50/60 Hz, 1.0A (Max.) Output - 12V DC, 2.5A. Power Consumption (Typical)- 25.4W. Neck/Stand Detachable: Yes "
           },
           new ProductDetails
           {
               Id = 7,
               ProductId = 2,
               Text = "2 x HDMI Ports (convertible to DVI).Contrast Ratio:1000 : 1"
           },
           new ProductDetails
           {
               Id = 8,
               ProductId = 2,
               Text = "VESA wall mount ready. HDMI Input Signal Support - 1920 x 1080 @ 75Hz, 1080/60p, 1080/60i, 720p, 480p, 480i, Built-in Speakers - 2 x 2W 8 Ohm.Mounting type: VESA Hole Pattern 100mm x 100mm"
           },

            new ProductDetails
            {
                Id = 9,
                ProductId = 3,
                Text = "24 Ultra slim profile "
            },
           new ProductDetails
           {
               Id = 10,
               ProductId = 3,
               Text = "Slim bezel with thin chassis. Power Range (V, A, Hz)- AC-DC Adapter Input 100 – 240 VAC, 50/60 Hz, 1.0A (Max.) Output - 12V DC, 2.5A. Power Consumption (Typical)- 25.4W. Neck/Stand Detachable: Yes "
           },
           new ProductDetails
           {
               Id = 11,
               ProductId = 3,
               Text = "2 x HDMI Ports (convertible to DVI).Contrast Ratio:1000 : 1"
           },
           new ProductDetails
           {
               Id = 12,
               ProductId = 3,
               Text = "VESA wall mount ready. HDMI Input Signal Support - 1920 x 1080 @ 75Hz, 1080/60p, 1080/60i, 720p, 480p, 480i, Built-in Speakers - 2 x 2W 8 Ohm.Mounting type: VESA Hole Pattern 100mm x 100mm"
           },

            new ProductDetails
            {
                Id = 13,
                ProductId = 4,
                Text = "24 Ultra slim profile "
            },
           new ProductDetails
           {
               Id = 14,
               ProductId = 4,
               Text = "Slim bezel with thin chassis. Power Range (V, A, Hz)- AC-DC Adapter Input 100 – 240 VAC, 50/60 Hz, 1.0A (Max.) Output - 12V DC, 2.5A. Power Consumption (Typical)- 25.4W. Neck/Stand Detachable: Yes "
           },
           new ProductDetails
           {
               Id = 15,
               ProductId = 4,
               Text = "2 x HDMI Ports (convertible to DVI).Contrast Ratio:1000 : 1"
           },
           new ProductDetails
           {
               Id = 16,
               ProductId = 4,
               Text = "VESA wall mount ready. HDMI Input Signal Support - 1920 x 1080 @ 75Hz, 1080/60p, 1080/60i, 720p, 480p, 480i, Built-in Speakers - 2 x 2W 8 Ohm.Mounting type: VESA Hole Pattern 100mm x 100mm"
           },

            new ProductDetails
            {
                Id = 17,
                ProductId = 5,
                Text = "24 Ultra slim profile "
            },
           new ProductDetails
           {
               Id = 18,
               ProductId = 5,
               Text = "Slim bezel with thin chassis. Power Range (V, A, Hz)- AC-DC Adapter Input 100 – 240 VAC, 50/60 Hz, 1.0A (Max.) Output - 12V DC, 2.5A. Power Consumption (Typical)- 25.4W. Neck/Stand Detachable: Yes "
           },
           new ProductDetails
           {
               Id = 19,
               ProductId = 5,
               Text = "2 x HDMI Ports (convertible to DVI).Contrast Ratio:1000 : 1"
           },
           new ProductDetails
           {
               Id = 20,
               ProductId = 5,
               Text = "VESA wall mount ready. HDMI Input Signal Support - 1920 x 1080 @ 75Hz, 1080/60p, 1080/60i, 720p, 480p, 480i, Built-in Speakers - 2 x 2W 8 Ohm.Mounting type: VESA Hole Pattern 100mm x 100mm"
           },

            new ProductDetails
            {
                Id = 21,
                ProductId = 6,
                Text = "24 Ultra slim profile "
            },
           new ProductDetails
           {
               Id = 22,
               ProductId = 6,
               Text = "Slim bezel with thin chassis. Power Range (V, A, Hz)- AC-DC Adapter Input 100 – 240 VAC, 50/60 Hz, 1.0A (Max.) Output - 12V DC, 2.5A. Power Consumption (Typical)- 25.4W. Neck/Stand Detachable: Yes "
           },
           new ProductDetails
           {
               Id = 23,
               ProductId = 6,
               Text = "2 x HDMI Ports (convertible to DVI).Contrast Ratio:1000 : 1"
           },
           new ProductDetails
           {
               Id = 24,
               ProductId = 6,
               Text = "VESA wall mount ready. HDMI Input Signal Support - 1920 x 1080 @ 75Hz, 1080/60p, 1080/60i, 720p, 480p, 480i, Built-in Speakers - 2 x 2W 8 Ohm.Mounting type: VESA Hole Pattern 100mm x 100mm"
           },

            new ProductDetails
            {
                Id = 25,
                ProductId = 7,
                Text = "24 Ultra slim profile "
            },
           new ProductDetails
           {
               Id = 26,
               ProductId = 7,
               Text = "Slim bezel with thin chassis. Power Range (V, A, Hz)- AC-DC Adapter Input 100 – 240 VAC, 50/60 Hz, 1.0A (Max.) Output - 12V DC, 2.5A. Power Consumption (Typical)- 25.4W. Neck/Stand Detachable: Yes "
           },
           new ProductDetails
           {
               Id = 27,
               ProductId = 7,
               Text = "2 x HDMI Ports (convertible to DVI).Contrast Ratio:1000 : 1"
           },
           new ProductDetails
           {
               Id = 28,
               ProductId = 7,
               Text = "VESA wall mount ready. HDMI Input Signal Support - 1920 x 1080 @ 75Hz, 1080/60p, 1080/60i, 720p, 480p, 480i, Built-in Speakers - 2 x 2W 8 Ohm.Mounting type: VESA Hole Pattern 100mm x 100mm"
           },

            new ProductDetails
            {
                Id = 29,
                ProductId = 8,
                Text = "24 Ultra slim profile "
            },
           new ProductDetails
           {
               Id = 30,
               ProductId = 8,
               Text = "Slim bezel with thin chassis. Power Range (V, A, Hz)- AC-DC Adapter Input 100 – 240 VAC, 50/60 Hz, 1.0A (Max.) Output - 12V DC, 2.5A. Power Consumption (Typical)- 25.4W. Neck/Stand Detachable: Yes "
           },
           new ProductDetails
           {
               Id = 31,
               ProductId = 8,
               Text = "2 x HDMI Ports (convertible to DVI).Contrast Ratio:1000 : 1"
           },
           new ProductDetails
           {
               Id = 32,
               ProductId = 8,
               Text = "VESA wall mount ready. HDMI Input Signal Support - 1920 x 1080 @ 75Hz, 1080/60p, 1080/60i, 720p, 480p, 480i, Built-in Speakers - 2 x 2W 8 Ohm.Mounting type: VESA Hole Pattern 100mm x 100mm"
           },

            new ProductDetails
            {
                Id = 33,
                ProductId = 9,
                Text = "24 Ultra slim profile "
            },
           new ProductDetails
           {
               Id = 34,
               ProductId = 9,
               Text = "Slim bezel with thin chassis. Power Range (V, A, Hz)- AC-DC Adapter Input 100 – 240 VAC, 50/60 Hz, 1.0A (Max.) Output - 12V DC, 2.5A. Power Consumption (Typical)- 25.4W. Neck/Stand Detachable: Yes "
           },
           new ProductDetails
           {
               Id = 35,
               ProductId = 9,
               Text = "2 x HDMI Ports (convertible to DVI).Contrast Ratio:1000 : 1"
           },
           new ProductDetails
           {
               Id = 36,
               ProductId = 9,
               Text = "VESA wall mount ready. HDMI Input Signal Support - 1920 x 1080 @ 75Hz, 1080/60p, 1080/60i, 720p, 480p, 480i, Built-in Speakers - 2 x 2W 8 Ohm.Mounting type: VESA Hole Pattern 100mm x 100mm"
           },

            new ProductDetails
            {
                Id = 37,
                ProductId = 10,
                Text = "24 Ultra slim profile "
            },
           new ProductDetails
           {
               Id = 38,
               ProductId = 10,
               Text = "Slim bezel with thin chassis. Power Range (V, A, Hz)- AC-DC Adapter Input 100 – 240 VAC, 50/60 Hz, 1.0A (Max.) Output - 12V DC, 2.5A. Power Consumption (Typical)- 25.4W. Neck/Stand Detachable: Yes "
           },
           new ProductDetails
           {
               Id = 39,
               ProductId = 10,
               Text = "2 x HDMI Ports (convertible to DVI).Contrast Ratio:1000 : 1"
           },
           new ProductDetails
           {
               Id = 40,
               ProductId = 10,
               Text = "VESA wall mount ready. HDMI Input Signal Support - 1920 x 1080 @ 75Hz, 1080/60p, 1080/60i, 720p, 480p, 480i, Built-in Speakers - 2 x 2W 8 Ohm.Mounting type: VESA Hole Pattern 100mm x 100mm"
           },

            new ProductDetails
            {
                Id = 41,
                ProductId = 11,
                Text = "24 Ultra slim profile "
            },
           new ProductDetails
           {
               Id = 42,
               ProductId = 11,
               Text = "Slim bezel with thin chassis. Power Range (V, A, Hz)- AC-DC Adapter Input 100 – 240 VAC, 50/60 Hz, 1.0A (Max.) Output - 12V DC, 2.5A. Power Consumption (Typical)- 25.4W. Neck/Stand Detachable: Yes "
           },
           new ProductDetails
           {
               Id = 43,
               ProductId = 11,
               Text = "2 x HDMI Ports (convertible to DVI).Contrast Ratio:1000 : 1"
           },
           new ProductDetails
           {
               Id = 44,
               ProductId = 11,
               Text = "VESA wall mount ready. HDMI Input Signal Support - 1920 x 1080 @ 75Hz, 1080/60p, 1080/60i, 720p, 480p, 480i, Built-in Speakers - 2 x 2W 8 Ohm.Mounting type: VESA Hole Pattern 100mm x 100mm"
           }
        );
    }
}
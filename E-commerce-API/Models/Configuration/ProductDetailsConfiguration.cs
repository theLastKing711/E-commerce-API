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
           }
        );
    }
}
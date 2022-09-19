using ECommerce.API.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {

        var password = new PasswordHasher<AppUser>();

        builder.HasData(
           new AppUser
           {
               Id = 100,
               Email = "appuser@gmail.com",
               PasswordHash = "laksjdflaksj",
               UserName = "appuser@gmail.com"
           },
           new AppUser
           {
               Id = 101,
               Email = "appuser2@gmail.com",
               PasswordHash = "laksjdflaksj",
               UserName = "appuser2@gmail.com"
           },
           new AppUser
           {
               Id = 102,
               Email = "appuser3@gmail.com",
               PasswordHash = "laksjdflaksj",
               UserName = "appuser3@gmail.com"
           },
           new AppUser
           {
               Id = 103,
               Email = "appuser4@gmail.com",
               PasswordHash = "laksjdflaksj",
               UserName = "appuser4@gmail.com"
           },
           new AppUser
           {
               Id = 104,
               Email = "appuser5@gmail.com",
               PasswordHash = "laksjdflaksj",
               UserName = "appuse54@gmail.com"
           }
        );

    }
}
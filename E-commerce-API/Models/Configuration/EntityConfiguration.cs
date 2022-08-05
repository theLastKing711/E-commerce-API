using ECommerce.API.Dtos.Identity;
using ECommerce.API.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RoleConfiguration : IEntityTypeConfiguration<AppRole>
{
    public void Configure(EntityTypeBuilder<AppRole> builder)
    {

        builder.HasData(
            new AppRole
            {
                Id = 1,
                Name = UserRoles.User,
                NormalizedName = "USER"
            },
            new AppRole
            {
                Id = 2,
                Name = UserRoles.Admin,
                NormalizedName = "ADMIN"
            }
        );
    }
}
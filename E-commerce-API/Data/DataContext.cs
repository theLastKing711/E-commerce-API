using ECommerce.API.Dtos;
using ECommerce.API.Models;
using ECommerce.API.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());


            // builder.Entity<AppRole>().HasData(
            //     new AppRole
            //     {
            //         Id = 1,
            //         Name = "Admin",
            //         NormalizedName = "ADMIN"
            //     },
            //     new AppRole
            //     {
            //         Id = 2,
            //         Name = "User",
            //         NormalizedName = "User"
            //     }
            // );

        }



        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<InvoiceDetails> InvoicesDetails { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Discount> Discounts { get; set; }

    }
}

using ECommerce.API.Dtos;
using ECommerce.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API
{
  public class DataContext : IdentityDbContext<IdentityUser>
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public DbSet<Category> Categories{ get; set; }


    public DbSet<Product> Products { get; set; }


  }
}

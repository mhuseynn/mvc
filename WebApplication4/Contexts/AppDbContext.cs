using Microsoft.EntityFrameworkCore;
using WebApplication4.Models.Concretes;

namespace WebApplication4.Contexts;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }


    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<ProductImage> Images { get; set; }

    public DbSet<Slider> Sliders { get; set; }

}

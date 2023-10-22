using Flowey.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Flowey.Services.ProductAPI.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasData(new Product()
        {
            ProductId = 1,
            Name = "Розы",
            CategoryName = "Цветы",
            Description = "Розы колючие",
            Price = 100,
            ImageUrl = ""
        });
        
        modelBuilder.Entity<Product>().HasData(new Product()
        {
            ProductId = 2,
            Name = "Лилии",
            CategoryName = "Цветы",
            Description = "Кросивый",
            Price = 150,
            ImageUrl = ""
        });
        
        modelBuilder.Entity<Product>().HasData(new Product()
        {
            ProductId = 3,
            Name = "Фикус",
            CategoryName = "Комнатные растения",
            Description = "Комнатные растения",
            Price = 500,
            ImageUrl = ""
        });
        
        modelBuilder.Entity<Product>().HasData(new Product()
        {
            ProductId = 4,
            Name = "Монстера",
            CategoryName = "Комнатные растения",
            Description = "Домашнее с большими листьями",
            Price = 1500,
            ImageUrl = ""
        });
    }
}
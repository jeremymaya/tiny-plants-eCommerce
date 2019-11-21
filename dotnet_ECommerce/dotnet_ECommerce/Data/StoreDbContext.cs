using dotnet_ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_ECommerce.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding Data
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ID = 1,
                    Sku = "CACS01",
                    Name = "Atlantic",
                    Price = 15,
                    Description = "",
                    Image = "/wwwroot/images/cactus_atlantic.jpg",
                },
                new Product
                {
                    ID = 2,
                    Sku = "CACS02",
                    Name = "Rosette",
                    Price = 12,
                    Description = "",
                    Image = "/wwwroot/images/cactus_rosette.jpg",
                },
                new Product
                {
                    ID = 3,
                    Sku = "CACS03",
                    Name = "Pastel",
                    Price = 8,
                    Description = "",
                    Image = "/wwwroot/images/cactus_pastel.jpg",
                },
                new Product
                {
                    ID = 4,
                    Sku = "CACS04",
                    Name = "Coral",
                    Price = 7,
                    Description = "",
                    Image = "/wwwroot/images/cactus_coral.jpg",
                },
                new Product
                {
                    ID = 5,
                    Sku = "CACS05",
                    Name = "Parakeet",
                    Price = 16,
                    Description = "",
                    Image = "/wwwroot/images/cactus_parakeet.jpg",
                },
                new Product
                {
                    ID = 6,
                    Sku = "CACS06",
                    Name = "Crimson",
                    Price = 14,
                    Description = "",
                    Image = "/wwwroot/images/cactus_crimson.jpg",
                }
                );
        }

        public DbSet<Product> Product { get; set; }
    }
}

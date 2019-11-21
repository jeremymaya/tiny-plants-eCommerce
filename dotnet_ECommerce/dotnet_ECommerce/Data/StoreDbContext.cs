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
                },
                new Product
                {
                    ID = 7,
                    Sku = "FLWS01",
                    Name = "Arctic",
                    Price = 24,
                    Description = "",
                    Image = "/wwwroot/images/flower_arctic.jpg",
                },
                new Product
                {
                    ID = 8,
                    Sku = "FLWS02",
                    Name = "Kokedama",
                    Price = 29,
                    Description = "",
                    Image = "/wwwroot/images/flower_kokedama.jpg",
                },
                new Product
                {
                    ID = 9,
                    Sku = "PLNS01",
                    Name = "Bamboo",
                    Price = 31,
                    Description = "",
                    Image = "/wwwroot/images/plant_bamboo.jpg",
                },
                new Product
                {
                    ID = 10,
                    Sku = "PLNS02",
                    Name = "Hyacinth",
                    Price = 31,
                    Description = "",
                    Image = "/wwwroot/images/plant_hyacinth.jpg",
                }
                );
        }

        public DbSet<Product> Product { get; set; }
    }
}

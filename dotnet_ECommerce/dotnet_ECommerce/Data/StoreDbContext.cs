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
                    Sku = "CAC001",
                    Name = "Atlantic",
                    Price = 12,
                    Description = "A combination of multiple small cactuses",
                    Image = "/wwwroot/images/cactus_atlantic.jpg",
                },
                new Product
                {
                    ID = 2,
                    Sku = "CAC002",
                    Name = "Rosette",
                    Price = 9,
                    Description = "A hot pink little cactus to bright up your room",
                    Image = "/wwwroot/images/cactus_rosette.jpg",
                },
                new Product
                {
                    ID = 3,
                    Sku = "CAC003",
                    Name = "Pastel",
                    Price = 7,
                    Description = "This cactus with elegant-looking glass is perfect for your desk",
                    Image = "/wwwroot/images/cactus_pastel.jpg",
                },
                new Product
                {
                    ID = 4,
                    Sku = "CAC004",
                    Name = "Coral",
                    Price = 10,
                    Description = "This cute little coral will definitely lighten up your mood",
                    Image = "/wwwroot/images/cactus_coral.jpg",
                },
                new Product
                {
                    ID = 5,
                    Sku = "CAC005",
                    Name = "Parakeet",
                    Price = 18,
                    Description = "The unique looking little parakeet is one of the tiny plants that you must have",
                    Image = "/wwwroot/images/cactus_parakeet.jpg",
                },
                new Product
                {
                    ID = 6,
                    Sku = "CAC006",
                    Name = "Crimson",
                    Price = 17,
                    Description = "This spiky and layered looking cactus is defenitely a rare found",
                    Image = "/wwwroot/images/cactus_crimson.jpg",
                },
                new Product
                {
                    ID = 7,
                    Sku = "FLW001",
                    Name = "Arctic",
                    Price = 24,
                    Description = "A blue orchid is one of the best indoor plants that you can have",
                    Image = "/wwwroot/images/flower_arctic.jpg",
                },
                new Product
                {
                    ID = 8,
                    Sku = "FLW002",
                    Name = "Kokedama",
                    Price = 29,
                    Description = "",
                    Image = "/wwwroot/images/flower_kokedama.jpg",
                },
                new Product
                {
                    ID = 9,
                    Sku = "PLN001",
                    Name = "Bamboo",
                    Price = 31,
                    Description = "",
                    Image = "/wwwroot/images/plant_bamboo.jpg",
                },
                new Product
                {
                    ID = 10,
                    Sku = "PLN002",
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

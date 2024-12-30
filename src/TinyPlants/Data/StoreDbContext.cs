using Microsoft.EntityFrameworkCore;
using TinyPlants.Models;

namespace TinyPlants.Data;

public class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Creating a composite key
        modelBuilder.Entity<CartItems>().HasKey(cartitems => new { cartitems.CartId, cartitems.ProductId });
        modelBuilder.Entity<OrderItems>().HasKey(orderitems => new { orderitems.OrderId, orderitems.ProductId });

        // Seeding Data
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Sku = "CAC001",
                Name = "Atlantic",
                Price = 12,
                Description = "A combination of multiple small cactuses",
                Image = "/images/CAC001.jpg",
                IsFeatured = true
            },
            new Product
            {
                Id = 2,
                Sku = "CAC002",
                Name = "Rosette",
                Price = 9,
                Description = "A hot pink little cactus to bright up your room",
                Image = "/images/CAC002.jpg",
                IsFeatured = true
            },
            new Product
            {
                Id = 3,
                Sku = "CAC003",
                Name = "Pastel",
                Price = 7,
                Description = "This cactus with elegant-looking glass is perfect for your desk",
                Image = "/images/CAC003.jpg",
                IsFeatured = false
            },
            new Product
            {
                Id = 4,
                Sku = "CAC004",
                Name = "Coral",
                Price = 10,
                Description = "This cute little coral will definitely lighten up your mood",
                Image = "/images/CAC004.jpg",
                IsFeatured = true
            },
            new Product
            {
                Id = 5,
                Sku = "CAC005",
                Name = "Parakeet",
                Price = 18,
                Description = "The unique looking little parakeet is one of the tiny plants that you must have",
                Image = "/images/CAC005.jpg",
                IsFeatured = false
            },
            new Product
            {
                Id = 6,
                Sku = "CAC006",
                Name = "Crimson",
                Price = 17,
                Description = "This spiky and layered looking cactus is defenitely a rare found",
                Image = "/images/CAC006.jpg",
                IsFeatured = false
            },
            new Product
            {
                Id = 7,
                Sku = "FLW001",
                Name = "Arctic",
                Price = 24,
                Description = "A blue orchid is one of the best indoor plants that you can have",
                Image = "/images/FLW001.jpg",
                IsFeatured = false
            },
            new Product
            {
                Id = 8,
                Sku = "FLW002",
                Name = "Violet Kokedama",
                Price = 29,
                Description = "This ornamental plant comes with violet flowers and kokedama that adds more style to your plant",
                Image = "/images/FLW002.jpg",
                IsFeatured = false
            },
            new Product
            {
                Id = 9,
                Sku = "PLN001",
                Name = "Bamboo",
                Price = 26,
                Description = "Bamboo is easy to take care of and it grows fast",
                Image = "/images/PLN001.jpg",
                IsFeatured = false
            },
            new Product
            {
                Id = 10,
                Sku = "PLN002",
                Name = "Hyacinth",
                Price = 22,
                Description = "This plant can live in water and it makes a great indoor plant",
                Image = "/images/PLN002.jpg",
                IsFeatured = false
            }
            );
    }

    public DbSet<Product> Product { get; set; }
    public DbSet<Cart> Cart { get; set; }
    public DbSet<CartItems> CartItems { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderItems> OrderItems { get; set; }
}

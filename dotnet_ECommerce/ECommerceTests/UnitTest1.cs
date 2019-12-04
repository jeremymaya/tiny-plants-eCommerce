using dotnet_ECommerce.Data;
using dotnet_ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System;
using Xunit;

namespace ECommerceTests
{
    public class UnitTest1
    {
        [Fact]
        public void CanCreateUser()
        {
            ApplicationUser user = new ApplicationUser();
            user.FirstName = "Nuggle";
            user.LastName = "Corgi";

            Assert.Equal("Nuggle", user.FirstName);
            Assert.Equal("Corgi", user.LastName);
        }

        [Fact]
        public void CanCreateProduct()
        {
            Product product = new Product();
            product.Name = "Tiny plant";
            product.Sku = "TEST001";
            product.Price = 5;
            product.Description = "This is a test tiny plant";

            Assert.Equal("Tiny plant", product.Name);
            Assert.Equal("TEST001", product.Sku);
            Assert.Equal(5, product.Price);
            Assert.Equal("This is a test tiny plant", product.Description);
        }

        [Fact]
        public async void CanAddProductToDb()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("CanAddProductToDb").Options;

            using (StoreDbContext context = new StoreDbContext(options))
            {
                Product product = new Product();
                product.Name = "Tiny plant";
                product.Sku = "TEST001";
                product.Price = 5;
                product.Description = "This is a test tiny plant";

                context.Product.Add(product);
                await context.SaveChangesAsync();

                Product result = await context.Product.FirstOrDefaultAsync(x => x.Name == product.Name);

                Assert.Equal("Tiny plant", result.Name);
            }
        }

        [Fact]
        public void CanCreateCartItems()
        {
            Cart cart = new Cart()
            {
                ID = 1,
                UserID = "user01"
            };

            CartItems cartItems = new CartItems()
            {

            };

        }

        [Fact]
        public void CanCreateCart()
        {

        }
    }
}

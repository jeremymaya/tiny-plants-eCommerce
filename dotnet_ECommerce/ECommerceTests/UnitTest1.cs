using dotnet_ECommerce.Data;
using dotnet_ECommerce.Models;
using dotnet_ECommerce.Models.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System;
using System.Collections.Generic;
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
            product.Name = "Tiny Plant";
            product.Sku = "TEST001";
            product.Price = 5;
            product.Description = "This is a test tiny plant";

            Assert.Equal("Tiny Plant", product.Name);
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


        [Fact]
        public async void CanCreateInventoryAsync()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("CanCreateInventoryAsync")
                .Options;

            using (StoreDbContext context = new StoreDbContext(options))
            {
                InventoryManager service = new InventoryManager(context);

                Product productOne = new Product();
                productOne.Name = "Tiny Plant";
                productOne.Sku = "TEST001";
                productOne.Price = 5;
                productOne.Description = "This is a test tiny plant one";
                productOne.IsFeatured = false;

                await service.CreateInventoryAsync(productOne);

                Product result = await context.Product.FirstOrDefaultAsync();

                Assert.Equal("Tiny Plant", result.Name);
                Assert.Equal("TEST001", result.Sku);
                Assert.Equal(5, result.Price);
                Assert.Equal("This is a test tiny plant one", result .Description);
            }
        }

        [Fact]
        public async void CanGetAllInventoriesAsync()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("CanGetAllInventoriesAsync")
                .Options;

            using (StoreDbContext context = new StoreDbContext(options))
            {
                InventoryManager service = new InventoryManager(context);

                Product productOne = new Product();
                productOne.Name = "Tiny Plant";
                productOne.Sku = "TEST001";
                productOne.Price = 5;
                productOne.Description = "This is a test tiny plant one";
                productOne.IsFeatured = false;

                await service.CreateInventoryAsync(productOne);

                Product productTwo = new Product();
                productTwo.Name = "Nuggle Corgi";
                productTwo.Sku = "TEST002";
                productTwo.Price = 10;
                productTwo.Description = "This is a test tiny plant two";
                productTwo.IsFeatured = true;

                await service.CreateInventoryAsync(productTwo);

                IList<Product> products = await service.GetAllInventoriesAsync();

                Assert.Equal("TEST001", products[0].Sku);
                Assert.Equal("TEST002", products[1].Sku);
            }
        }

        [Fact]
        public async void CanGetFeaturedInventoriesAsync()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("CanGetFeaturedInventoriesAsync")
                .Options;

            using (StoreDbContext context = new StoreDbContext(options))
            {
                InventoryManager service = new InventoryManager(context);

                Product productOne = new Product();
                productOne.Name = "Tiny Plant";
                productOne.Sku = "TEST001";
                productOne.Price = 5;
                productOne.Description = "This is a test tiny plant one";
                productOne.IsFeatured = false;

                await service.CreateInventoryAsync(productOne);

                Product productTwo = new Product();
                productTwo.Name = "Nuggle Corgi";
                productTwo.Sku = "TEST002";
                productTwo.Price = 10;
                productTwo.Description = "This is a test tiny plant two";
                productTwo.IsFeatured = true;

                await service.CreateInventoryAsync(productTwo);

                IList<Product> featuredProducts = await service.GetFeaturedInventoriesAsync();

                Assert.Equal("TEST002", featuredProducts[0].Sku);
            }
        }

        [Fact]
        public async void CanGetInventoryByIdAsync()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("CanGetInventoryByIdAsync")
                .Options;

            using (StoreDbContext context = new StoreDbContext(options))
            {
                InventoryManager service = new InventoryManager(context);

                Product productOne = new Product();
                productOne.Name = "Tiny Plant";
                productOne.Sku = "TEST001";
                productOne.Price = 5;
                productOne.Description = "This is a test tiny plant one";
                productOne.IsFeatured = false;

                await service.CreateInventoryAsync(productOne);

                Product productTwo = new Product();
                productTwo.Name = "Nuggle Corgi";
                productTwo.Sku = "TEST002";
                productTwo.Price = 10;
                productTwo.Description = "This is a test tiny plant two";
                productTwo.IsFeatured = true;

                await service.CreateInventoryAsync(productTwo);

                Product result = await service.GetInventoryByIdAsync(2);

                Assert.Equal("TEST002", result.Sku);
            }
        }

        [Fact]
        public async void CanUpdateInventoryAsync()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("CanUpdateInventoryAsync")
                .Options;

            using (StoreDbContext context = new StoreDbContext(options))
            {
                InventoryManager service = new InventoryManager(context);

                Product productOne = new Product();
                productOne.Name = "Tiny Plant";
                productOne.Sku = "TEST001";
                productOne.Price = 5;
                productOne.Description = "This is a test tiny plant one";
                productOne.IsFeatured = false;

                await service.CreateInventoryAsync(productOne);

                productOne.Sku = "TEST003";

                await service.UpdateInventoryAsync(productOne);

                Assert.Equal("TEST003", productOne.Sku);
            }
        }

        [Fact]
        public async void CanRemoveInventoryAsync()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("CanRemoveInventoryAsync")
                .Options;

            using (StoreDbContext context = new StoreDbContext(options))
            {
                InventoryManager service = new InventoryManager(context);

                Product productOne = new Product();
                productOne.Name = "Tiny Plant";
                productOne.Sku = "TEST001";
                productOne.Price = 5;
                productOne.Description = "This is a test tiny plant one";
                productOne.IsFeatured = false;

                await service.CreateInventoryAsync(productOne);

                Product productTwo = new Product();
                productTwo.Name = "Nuggle Corgi";
                productTwo.Sku = "TEST002";
                productTwo.Price = 10;
                productTwo.Description = "This is a test tiny plant two";
                productTwo.IsFeatured = true;

                await service.CreateInventoryAsync(productTwo);

                await service.RemoveInventoryAsync(1);
                IList<Product> products = await service.GetAllInventoriesAsync();

                Assert.Equal("TEST002", products[0].Sku);
            }
        }

        [Fact]
        public async void CanCreateOrder()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>().UseInMemoryDatabase("CanAddOrderToDb").Options;

            using (StoreDbContext context = new StoreDbContext(options))
            {
                Order order = new Order();
                order.FirstName= "Nuggle";
                order.LastName = "Corgi";
                order.Address= "1234 Nuggle Corgi Street";
                order.City = "Seattle";
                order.State = "WA";
                order.Zip = "98121";

                context.Order.Add(order);
                await context.SaveChangesAsync();

                Order result = await context.Order.FirstOrDefaultAsync();

                Assert.Equal("Nuggle", result.FirstName);
                Assert.Equal("Corgi", result.LastName);
                Assert.Equal("1234 Nuggle Corgi Street", result.Address);
                Assert.Equal("Seattle", result.City);
                Assert.Equal("WA", result.State);
                Assert.Equal("98121", result.Zip);
            }
        }

        [Fact]
        public async void CanCreateOrderItems()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>().UseInMemoryDatabase("CanAddOrderItemsToDb").Options;

            using (StoreDbContext context = new StoreDbContext(options))
            {
                Product product = new Product();
                product.Name = "Tiny Plant";
                product.Sku = "TEST001";
                product.Price = 5;
                product.Description = "This is a test tiny plant";

                context.Product.Add(product);
                await context.SaveChangesAsync();

                OrderItems orderItem = new OrderItems();
                orderItem.ProductID = 1;
                orderItem.Quantity = 5;

                context.OrderItems.Add(orderItem);
                await context.SaveChangesAsync();

                OrderItems result = await context.OrderItems.FirstOrDefaultAsync();

                Assert.Equal("Tiny Plant", result.Product.Name);
                Assert.Equal("TEST001", result.Product.Sku);
                Assert.Equal(5, result.Product.Price);
                Assert.Equal("This is a test tiny plant", result.Product.Description);
                Assert.Equal(5, result.Quantity);
            }
        }
    }
}

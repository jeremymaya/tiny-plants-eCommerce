using dotnet_ECommerce.Data;
using dotnet_ECommerce.Models;
using dotnet_ECommerce.Models.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ECommerceTests
{
    public class UnitTest1
    {
        #region GetterSetterTests
        [Fact]
        public void GetterSetterUser()
        {
            ApplicationUser user = new ApplicationUser();
            user.FirstName = "Nuggle";
            user.LastName = "Corgi";

            Assert.Equal("Nuggle", user.FirstName);
            Assert.Equal("Corgi", user.LastName);
        }

        [Fact]
        public void GetterSetterProduct()
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
        public void GetterSetterCart()
        {
            Cart cart = new Cart()
            {
                UserID = "nugglecorgi@test.com"
            };

            Assert.Equal("nugglecorgi@test.com", cart.UserID);
        }

        [Fact]
        public void GetterSetterCartItem()
        {
            CartItems cartItem = new CartItems()
            {
                CartID = 1,
                ProductID = 1,
                Quantity = 100
            };

            Assert.Equal(1, cartItem.CartID);
            Assert.Equal(1, cartItem.ProductID);
            Assert.Equal(100, cartItem.Quantity);
        }

        [Fact]
        public void GetterSetterOrder()
        {
            Order orderOne = new Order()
            {
                UserID = "nugglecorgi@test.com",
                FirstName = "Nuggle",
                LastName = "Corgi",
                Address = "1234 Tiny Street",
                City = "Seattle",
                State = "WA",
                Zip = "98121",
                CreditCard = "VISA-XXXX",
            };

            Assert.Equal("nugglecorgi@test.com", orderOne.UserID);
            Assert.Equal("Nuggle", orderOne.FirstName);
            Assert.Equal("Corgi", orderOne.LastName);
            Assert.Equal("1234 Tiny Street", orderOne.Address);
            Assert.Equal("Seattle", orderOne.City);
            Assert.Equal("WA", orderOne.State);
            Assert.Equal("98121", orderOne.Zip);
            Assert.Equal("VISA-XXXX", orderOne.CreditCard);
        }

        [Fact]
        public void GetterSetterOrderItems()
        {
            OrderItems orderItem = new OrderItems()
            {
                OrderID = 1,
                ProductID = 1,
                Quantity = 5,
            };

            Assert.Equal(1, orderItem.OrderID);
            Assert.Equal(1, orderItem.ProductID);
            Assert.Equal(5, orderItem.Quantity);
        }

        [Fact]
        public void GetterSetterEmail()
        {
            Email email = new Email()
            {
                ToEmail = "nugglecorgi@test.com",
                Subject = "Test",
                Message = "Message"
            };

            Assert.Equal("nugglecorgi@test.com", email.ToEmail);
            Assert.Equal("Test", email.Subject);
            Assert.Equal("Message", email.Message);
        }
        #endregion

        #region CRUD for Product
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
                Assert.Equal("This is a test tiny plant one", result.Description);
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
        #endregion

        #region CRUD for Cart and CartItems
        [Fact]
        public async void CanCreateCartAsync()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("CanCreateCartAsync")
                .Options;

            using (StoreDbContext context = new StoreDbContext(options))
            {
                ShopManager service = new ShopManager(context);

                Cart cart = new Cart();
                cart.UserID = "nugglecorgi@test.com";

                await service.CreateCartAsync(cart);

                Cart result = await context.Cart.FirstOrDefaultAsync();

                Assert.Equal("nugglecorgi@test.com", result.UserID);
            }
        }

        [Fact]
        public async void CanGetCartByUserIdAsync()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("CanGetCartByUserIdAsync")
                .Options;

            using (StoreDbContext context = new StoreDbContext(options))
            {
                ShopManager shop = new ShopManager(context);

                Cart cart = new Cart
                {
                    UserID = "nugglecorgi@test.com"
                };

                await shop.CreateCartAsync(cart);

                Cart result = await shop.GetCartByUserIdAsync("nugglecorgi@test.com");

                Assert.Equal(1, result.ID);
            }
        }

        [Fact]
        public async void CanCreateCartItemAsync()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("CanCreateCartItemAsync")
                .Options;

            using (StoreDbContext context = new StoreDbContext(options))
            {
                ShopManager shop = new ShopManager(context);
                InventoryManager inventory = new InventoryManager(context);

                Product product = new Product
                {
                    Name = "Tiny Plant",
                    Sku = "TEST001",
                    Price = 5,
                    Description = "This is a test tiny plant"
                };

                Cart cart = new Cart
                {
                    UserID = "nugglecorgi@test.com"
                };

                CartItems cartItem = new CartItems
                {
                    CartID = 1,
                    ProductID = 1,
                    Quantity = 5
                };

                await inventory.CreateInventoryAsync(product);
                await shop.CreateCartAsync(cart);
                await shop.CreateCartItemAsync(cartItem);

                CartItems result = await context.CartItems.FirstOrDefaultAsync();

                Assert.Equal("TEST001", result.Product.Sku);
                Assert.Equal("nugglecorgi@test.com", result.Cart.UserID);
                Assert.Equal(5, result.Quantity);
            }
        }

        [Fact]
        public async void CanGetCartItemsByUserIdAsync()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("CanGetCartItemsByUserIdAsync")
                .Options;

            using (StoreDbContext context = new StoreDbContext(options))
            {
                ShopManager shop = new ShopManager(context);
                InventoryManager inventory = new InventoryManager(context);

                Product productOne = new Product
                {
                    Name = "Tiny Plant",
                    Sku = "TEST001",
                    Price = 5,
                    Description = "This is a test tiny plant"
                };

                Product productTwo = new Product
                {
                    Name = "Nuggle Corgi",
                    Sku = "TEST002",
                    Price = 10,
                    Description = "This is a test tiny plant two"
                };

                Cart cart = new Cart
                {
                    UserID = "nugglecorgi@test.com"
                };

                CartItems cartItemOne = new CartItems
                {
                    CartID = 1,
                    ProductID = 1,
                    Quantity = 5
                };

                CartItems cartItemTwo = new CartItems
                {
                    CartID = 1,
                    ProductID = 2,
                    Quantity = 10
                };

                await inventory.CreateInventoryAsync(productOne);
                await inventory.CreateInventoryAsync(productTwo);
                await shop.CreateCartAsync(cart);
                await shop.CreateCartItemAsync(cartItemOne);
                await shop.CreateCartItemAsync(cartItemTwo);

                IEnumerable<CartItems> cartItems = await shop.GetCartItemsByUserIdAsync(cart.UserID);

                Assert.Equal("TEST001", cartItems.ElementAt(0).Product.Sku);
                Assert.Equal("TEST002", cartItems.ElementAt(1).Product.Sku);
                Assert.Equal("nugglecorgi@test.com", cartItems.ElementAt(0).Cart.UserID);
            }
        }

        [Fact]
        public async void CanUpdateCartItemsAsync()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("CanUpdateCartItemsAsync")
                .Options;

            using (StoreDbContext context = new StoreDbContext(options))
            {
                ShopManager shop = new ShopManager(context);
                InventoryManager inventory = new InventoryManager(context);

                Product product = new Product
                {
                    Name = "Tiny Plant",
                    Sku = "TEST001",
                    Price = 5,
                    Description = "This is a test tiny plant"
                };

                Cart cart = new Cart
                {
                    UserID = "nugglecorgi@test.com"
                };

                CartItems cartItem = new CartItems
                {
                    CartID = 1,
                    ProductID = 1,
                    Quantity = 5
                };

                await inventory.CreateInventoryAsync(product);
                await shop.CreateCartAsync(cart);
                await shop.CreateCartItemAsync(cartItem);

                cartItem.Quantity = 10;

                await shop.UpdateCartItemsAsync(cartItem);

                Assert.Equal(10, cartItem.Quantity);
            }
        }

        [Fact]
        public async void CanRemoveCartItemAsync()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("CanRemoveCartItemAsync")
                .Options;

            using (StoreDbContext context = new StoreDbContext(options))
            {
                ShopManager shop = new ShopManager(context);
                InventoryManager inventory = new InventoryManager(context);

                Product productOne = new Product
                {
                    Name = "Tiny Plant",
                    Sku = "TEST001",
                    Price = 5,
                    Description = "This is a test tiny plant"
                };

                Product productTwo = new Product
                {
                    Name = "Nuggle Corgi",
                    Sku = "TEST002",
                    Price = 10,
                    Description = "This is a test tiny plant two"
                };

                Cart cart = new Cart
                {
                    UserID = "nugglecorgi@test.com"
                };

                CartItems cartItemOne = new CartItems
                {
                    CartID = 1,
                    ProductID = 1,
                    Quantity = 5
                };

                CartItems cartItemTwo = new CartItems
                {
                    CartID = 1,
                    ProductID = 2,
                    Quantity = 10
                };

                await inventory.CreateInventoryAsync(productOne);
                await inventory.CreateInventoryAsync(productTwo);
                await shop.CreateCartAsync(cart);
                await shop.CreateCartItemAsync(cartItemOne);
                await shop.CreateCartItemAsync(cartItemTwo);

                await shop.RemoveCartItemsAsync(cart.UserID, 1);

                CartItems result = await context.CartItems.FirstOrDefaultAsync();

                Assert.Equal("TEST002", result.Product.Sku);
            }
        }

        [Fact]
        public async void CanRemoveCartItemsAsync()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("CanRemoveCartItemsAsync")
                .Options;

            using (StoreDbContext context = new StoreDbContext(options))
            {
                ShopManager shop = new ShopManager(context);
                InventoryManager inventory = new InventoryManager(context);

                Product productOne = new Product
                {
                    Name = "Tiny Plant",
                    Sku = "TEST001",
                    Price = 5,
                    Description = "This is a test tiny plant"
                };

                Product productTwo = new Product
                {
                    Name = "Nuggle Corgi",
                    Sku = "TEST002",
                    Price = 10,
                    Description = "This is a test tiny plant two"
                };

                Cart cart = new Cart
                {
                    UserID = "nugglecorgi@test.com"
                };

                CartItems cartItemOne = new CartItems
                {
                    CartID = 1,
                    ProductID = 1,
                    Quantity = 5
                };

                CartItems cartItemTwo = new CartItems
                {
                    CartID = 1,
                    ProductID = 2,
                    Quantity = 10
                };

                await inventory.CreateInventoryAsync(productOne);
                await inventory.CreateInventoryAsync(productTwo);
                await shop.CreateCartAsync(cart);
                await shop.CreateCartItemAsync(cartItemOne);
                await shop.CreateCartItemAsync(cartItemTwo);

                IEnumerable<CartItems> cartItems = await shop.GetCartItemsByUserIdAsync(cart.UserID);

                await shop.RemoveCartItemsAsync(cartItems);

                CartItems result = await context.CartItems.FirstOrDefaultAsync();

                Assert.Null(result);
            }
        }
        #endregion

        #region CRU for Order and OrderItems
        [Fact]
        public async void CanSaveOrderAsync()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("CanSaveOrderAsync")
                .Options;

            using (StoreDbContext context = new StoreDbContext(options))
            {
                OrderManager testOrderManager = new OrderManager(context);

                Order orderOne = new Order()
                {
                    UserID = "nugglecorgi@test.com",
                    FirstName = "Nuggle",
                    LastName = "Corgi",
                    Address = "1234 Tiny Street",
                    City = "Seattle",
                    State = "WA",
                    Zip = "98121",
                    CreditCard = "VISA-XXXX",
                };

                await testOrderManager.SaveOrderAsync(orderOne);

                Order result = await context.Order.FirstOrDefaultAsync();

                Assert.Equal("nugglecorgi@test.com", result.UserID);
                Assert.Equal("Nuggle", result.FirstName);
                Assert.Equal("Corgi", result.LastName);
                Assert.Equal("1234 Tiny Street", result.Address);
                Assert.Equal("Seattle", result.City);
                Assert.Equal("WA", result.State);
                Assert.Equal("98121", result.Zip);
                Assert.Equal("VISA-XXXX", result.CreditCard);
            }
        }

        [Fact]
        public async void CanGetOrdersAsync()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("CanGetOrdersAsync")
                .Options;

            using (StoreDbContext context = new StoreDbContext(options))
            {
                OrderManager testOrderManager = new OrderManager(context);

                Order orderOne = new Order()
                {
                    UserID = "nugglecorgi@test.com",
                    FirstName = "Nuggle",
                    LastName = "Corgi",
                    Address = "1234 Tiny Street",
                    City = "Seattle",
                    State = "WA",
                    Zip = "98121",
                    CreditCard = "VISA-XXXX",
                };

                Order orderTwo = new Order()
                {
                    UserID = "test@test.com",
                    FirstName = "Test",
                    LastName = "Two",
                    Address = "1234 Tiny Street",
                    City = "Seattle",
                    State = "WA",
                    Zip = "98121",
                    CreditCard = "MASTER-XXXX",
                };

                await testOrderManager.SaveOrderAsync(orderOne);
                await testOrderManager.SaveOrderAsync(orderTwo);

                IEnumerable<Order> orders = await testOrderManager.GetOrdersAsync();

                Assert.Equal("Nuggle", orders.ElementAt(0).FirstName);
                Assert.Equal("Corgi", orders.ElementAt(0).LastName);
                Assert.Equal("VISA-XXXX", orders.ElementAt(0).CreditCard);
                Assert.Equal("Test", orders.ElementAt(1).FirstName);
                Assert.Equal("Two", orders.ElementAt(1).LastName);
                Assert.Equal("MASTER-XXXX", orders.ElementAt(1).CreditCard);
            }
        }

        [Fact]
        public async void CanGetOrdersByUserIdAsync()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("CanGetOrdersByUserIdAsync")
                .Options;

            using (StoreDbContext context = new StoreDbContext(options))
            {
                OrderManager testOrderManager = new OrderManager(context);

                Order orderOne = new Order()
                {
                    UserID = "nugglecorgi@test.com",
                    FirstName = "Nuggle",
                    LastName = "Corgi",
                    Address = "1234 Tiny Street",
                    City = "Seattle",
                    State = "WA",
                    Zip = "98121",
                    CreditCard = "VISA-XXXX",
                };

                Order orderTwo = new Order()
                {
                    UserID = "test@test.com",
                    FirstName = "Test",
                    LastName = "Two",
                    Address = "1234 Tiny Street",
                    City = "Seattle",
                    State = "WA",
                    Zip = "98121",
                    CreditCard = "MASTER-XXXX",
                };

                await testOrderManager.SaveOrderAsync(orderOne);
                await testOrderManager.SaveOrderAsync(orderTwo);

                IEnumerable<Order> orders = await testOrderManager.GetOrdersByUserIdAsync(orderTwo.UserID);

                Assert.Equal("Test", orders.ElementAt(0).FirstName);
                Assert.Equal("Two", orders.ElementAt(0).LastName);
                Assert.Equal("MASTER-XXXX", orders.ElementAt(0).CreditCard);
            }
        }

        [Fact]
        public async void CanGetLatestOrderForUserAsync()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("CanGetLatestOrderForUserAsync")
                .Options;

            using (StoreDbContext context = new StoreDbContext(options))
            {
                OrderManager testOrderManager = new OrderManager(context);

                Order orderOne = new Order()
                {
                    UserID = "nugglecorgi@test.com",
                    FirstName = "Nuggle",
                    LastName = "Corgi",
                    Address = "1234 Tiny Street",
                    City = "Seattle",
                    State = "WA",
                    Zip = "98121",
                    CreditCard = "VISA-XXXX",
                };

                Order orderTwo = new Order()
                {
                    UserID = "nugglecorgi@test.com",
                    FirstName = "Test",
                    LastName = "Two",
                    Address = "1234 Tiny Street",
                    City = "Seattle",
                    State = "WA",
                    Zip = "98121",
                    CreditCard = "MASTER-XXXX",
                };

                await testOrderManager.SaveOrderAsync(orderOne);
                await testOrderManager.SaveOrderAsync(orderTwo);

                Order order = await testOrderManager.GetLatestOrderForUserAsync(orderTwo.UserID);

                Assert.Equal("Test", order.FirstName);
                Assert.Equal("Two", order.LastName);
                Assert.Equal("MASTER-XXXX", order.CreditCard);
            }
        }

        [Fact]
        public async void CanSaveOrderItemAsync()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("CanSaveOrderItemAsync")
                .Options;

            using (StoreDbContext context = new StoreDbContext(options))
            {
                InventoryManager testInventoryManager = new InventoryManager(context);
                OrderManager testOrderManager = new OrderManager(context);

                Product productOne = new Product
                {
                    Name = "Tiny Plant",
                    Sku = "TEST001",
                    Price = 5,
                    Description = "This is a test tiny plant"
                };

                Order orderOne = new Order()
                {
                    UserID = "nugglecorgi@test.com",
                    FirstName = "Nuggle",
                    LastName = "Corgi",
                    Address = "1234 Tiny Street",
                    City = "Seattle",
                    State = "WA",
                    Zip = "98121",
                    CreditCard = "VISA-XXXX",
                };

                OrderItems orderItemsOne = new OrderItems()
                {
                    OrderID = 1,
                    ProductID = 1,
                    Quantity = 5,
                };

                await testInventoryManager.CreateInventoryAsync(productOne);
                await testOrderManager.SaveOrderAsync(orderOne);
                await testOrderManager.SaveOrderItemAsync(orderItemsOne);

                OrderItems result = await context.OrderItems.FirstOrDefaultAsync();

                Assert.Equal("TEST001", result.Product.Sku);
                Assert.Equal("nugglecorgi@test.com", result.Order.UserID);
                Assert.Equal(5, result.Quantity);
            }
        }

        [Fact]
        public async void CanGetOrderItemsAsync()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("CanGetOrderItemsAsync")
                .Options;

            using (StoreDbContext context = new StoreDbContext(options))
            {
                InventoryManager testInventoryManager = new InventoryManager(context);
                OrderManager testOrderManager = new OrderManager(context);

                Product productOne = new Product
                {
                    Name = "Tiny Plant",
                    Sku = "TEST001",
                    Price = 5,
                    Description = "This is a test tiny plant"
                };

                Product productTwo = new Product
                {
                    Name = "Nuggle Corgi",
                    Sku = "TEST002",
                    Price = 10,
                    Description = "This is a test tiny plant two"
                };

                Order orderOne = new Order()
                {
                    UserID = "nugglecorgi@test.com",
                    FirstName = "Nuggle",
                    LastName = "Corgi",
                    Address = "1234 Tiny Street",
                    City = "Seattle",
                    State = "WA",
                    Zip = "98121",
                    CreditCard = "VISA-XXXX",
                };

                OrderItems orderItemsOne = new OrderItems()
                {
                    OrderID = 1,
                    ProductID = 1,
                    Quantity = 5,
                };

                OrderItems orderItemsTwo = new OrderItems()
                {
                    OrderID = 1,
                    ProductID = 2,
                    Quantity = 100,
                };

                await testInventoryManager.CreateInventoryAsync(productOne);
                await testInventoryManager.CreateInventoryAsync(productTwo);
                await testOrderManager.SaveOrderAsync(orderOne);
                await testOrderManager.SaveOrderItemAsync(orderItemsOne);
                await testOrderManager.SaveOrderItemAsync(orderItemsTwo);

                IEnumerable<OrderItems> result = await testOrderManager.GetOrderItemsAsync();

                Assert.Equal("TEST001", result.ElementAt(0).Product.Sku);
                Assert.Equal("nugglecorgi@test.com", result.ElementAt(0).Order.UserID);
                Assert.Equal(5, result.ElementAt(0).Quantity);
                Assert.Equal("TEST002", result.ElementAt(1).Product.Sku);
                Assert.Equal("nugglecorgi@test.com", result.ElementAt(1).Order.UserID);
                Assert.Equal(100, result.ElementAt(1).Quantity);
            }
        }

        [Fact]
        public async void CanGetOrderItemsByOrderIdAsync()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("CanGetOrderItemsByOrderIdAsync")
                .Options;

            using (StoreDbContext context = new StoreDbContext(options))
            {
                InventoryManager testInventoryManager = new InventoryManager(context);
                OrderManager testOrderManager = new OrderManager(context);

                Product productOne = new Product
                {
                    Name = "Tiny Plant",
                    Sku = "TEST001",
                    Price = 5,
                    Description = "This is a test tiny plant"
                };

                Order orderOne = new Order()
                {
                    UserID = "nugglecorgi@test.com",
                    FirstName = "Nuggle",
                    LastName = "Corgi",
                    Address = "1234 Tiny Street",
                    City = "Seattle",
                    State = "WA",
                    Zip = "98121",
                    CreditCard = "VISA-XXXX",
                };

                Order orderTwo = new Order()
                {
                    UserID = "test@test.com",
                    FirstName = "Test",
                    LastName = "Two",
                    Address = "1234 Tiny Street",
                    City = "Seattle",
                    State = "WA",
                    Zip = "98121",
                    CreditCard = "MASTER-XXXX",
                };

                OrderItems orderItemsOne = new OrderItems()
                {
                    OrderID = 1,
                    ProductID = 1,
                    Quantity = 5,
                };

                OrderItems orderItemsTwo = new OrderItems()
                {
                    OrderID = 2,
                    ProductID = 1,
                    Quantity = 100,
                };

                await testInventoryManager.CreateInventoryAsync(productOne);
                await testOrderManager.SaveOrderAsync(orderOne);
                await testOrderManager.SaveOrderAsync(orderTwo);
                await testOrderManager.SaveOrderItemAsync(orderItemsOne);
                await testOrderManager.SaveOrderItemAsync(orderItemsTwo);

                IEnumerable<OrderItems> result = await testOrderManager.GetOrderItemsByOrderIdAsync(2);

                Assert.Equal("TEST001", result.ElementAt(0).Product.Sku);
                Assert.Equal("test@test.com", result.ElementAt(0).Order.UserID);
                Assert.Equal(100, result.ElementAt(0).Quantity);
            }
        }

        [Fact]
        public async void CanUpdateOrderItemsAsync()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("CanUpdateOrderItemsAsync")
                .Options;

            using (StoreDbContext context = new StoreDbContext(options))
            {
                InventoryManager testInventoryManager = new InventoryManager(context);
                OrderManager testOrderManager = new OrderManager(context);

                Product productOne = new Product
                {
                    Name = "Tiny Plant",
                    Sku = "TEST001",
                    Price = 5,
                    Description = "This is a test tiny plant"
                };

                Order orderOne = new Order()
                {
                    UserID = "nugglecorgi@test.com",
                    FirstName = "Nuggle",
                    LastName = "Corgi",
                    Address = "1234 Tiny Street",
                    City = "Seattle",
                    State = "WA",
                    Zip = "98121",
                    CreditCard = "VISA-XXXX",
                };

                OrderItems orderItemsOne = new OrderItems()
                {
                    OrderID = 1,
                    ProductID = 1,
                    Quantity = 5,
                };

                await testInventoryManager.CreateInventoryAsync(productOne);
                await testOrderManager.SaveOrderAsync(orderOne);
                await testOrderManager.SaveOrderItemAsync(orderItemsOne);

                orderItemsOne.Quantity = 100;

                await testOrderManager.UpdateOrderItemsAsync(orderItemsOne);

                Assert.Equal(100, orderItemsOne.Quantity);
            }
        }
        #endregion
    }
}

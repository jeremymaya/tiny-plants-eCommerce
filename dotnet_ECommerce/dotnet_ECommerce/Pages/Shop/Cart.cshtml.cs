using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ECommerce.Models;
using dotnet_ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet_ECommerce.Pages.Shop
{
    public class CartModel : PageModel
    {
        /// <summary>
        /// Dependency injection to establish a private connection to a database table by injecting an interface
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IShop _shop;

        /// <summary>
        /// Dependency injection to establish a private connection to a database table by injecting an interface
        /// </summary>
        private readonly IInventory _inventory;

        /// <summary>
        /// A contructor to set propety to the corresponding interface instance
        /// </summary>
        /// <param name="context">IInventory interface</param>
        public CartModel(IShop shopcontext, IInventory inventory, UserManager<ApplicationUser> userManager)
        {
            _shop = shopcontext;
            _inventory = inventory;
            _userManager = userManager;
        }

        /// <summary>
        /// A property to be available on the Model property in the Razor Page
        /// </summary>
        public IList<CartItems> CartItem { get; set; }

        /// <summary>
        /// A property to be available on the Model property in the Razor Page
        /// </summary>
        public IEnumerable<Cart> Cart { get; set; }

        public Product Product { get; set; }

        /// <summary>
        /// Asynchronous handler method to process the default GET request
        /// </summary>
        /// <returns>List of all cart items from the database</returns>
        public async Task OnGetAsync()
        {
            //var user = await _userManager.GetUserAsync(User);
            //var carts = await _shop.GetCartsAsync();
            //var cart = carts.Where(x => x.UserID == user.Id);

            CartItem = await _shop.GetCartItemsAsync();
        }
    }
}

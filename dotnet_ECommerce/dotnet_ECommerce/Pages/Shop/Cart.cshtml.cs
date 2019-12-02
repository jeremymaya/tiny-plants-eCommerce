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
        /// A contructor to set propety to the corresponding interface instance
        /// </summary>
        /// <param name="context">IInventory interface</param>
        public CartModel(UserManager<ApplicationUser> userManager, IShop shopcontext)
        {
            _shop = shopcontext;
            _userManager = userManager;
        }

        /// <summary>
        /// A property to be available on the Model property in the Razor Page
        /// </summary>
        public IEnumerable<CartItems> CartItem { get; set; }

        /// <summary>
        /// Asynchronous handler method to process the default GET request
        /// </summary>
        /// <returns>List of all cart items from the database</returns>
        public async Task OnGetAsync()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            CartItem = await _shop.GetCartItemsByUserIdAsync(user.Id);
        }

        public async Task<IActionResult> OnPostUpdateAsync(int id)
        {
            int updatedQuantity = Convert.ToInt32(Request.Form["Quantity"]);
            ApplicationUser user = await _userManager.GetUserAsync(User);
            CartItems cartItem = await _shop.GetCartItemByProductIdForUserAsync(user.Id, id);

            cartItem.Quantity = updatedQuantity;
            await _shop.UpdateCartItemsAsync(cartItem);

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            await _shop.RemoveCartItemsAsync(user.Id, id);

            return RedirectToPage();
        }
    }
}

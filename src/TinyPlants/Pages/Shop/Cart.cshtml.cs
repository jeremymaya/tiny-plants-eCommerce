using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TinyPlants.Models;
using TinyPlants.Models.Interfaces;

namespace TinyPlants.Pages.Shop
{
    public class CartModel : PageModel
    {
        /// <summary>
        /// Dependency injection to establish a private connection to a database table by injecting an interface
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly IShopManager _shopManager;

        /// <summary>
        /// A contructor to set propety to the corresponding interface instance
        /// </summary>
        /// <param name="context">IInventory interface</param>
        public CartModel(UserManager<ApplicationUser> userManager, IShopManager shopManager, IEmailSender emailSender)
        {
            _shopManager = shopManager;
            _userManager = userManager;
            _emailSender = emailSender;
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
            CartItem = await _shopManager.GetCartItemsByUserIdAsync(user.Id);
        }

        public async Task<IActionResult> OnPostUpdateAsync(int id)
        {
            int updatedQuantity = Convert.ToInt32(Request.Form["Quantity"]);
            ApplicationUser user = await _userManager.GetUserAsync(User);
            CartItems cartItem = await _shopManager.GetCartItemByProductIdForUserAsync(user.Id, id);

            cartItem.Quantity = updatedQuantity;
            await _shopManager.UpdateCartItemsAsync(cartItem);

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            await _shopManager.RemoveCartItemsAsync(user.Id, id);

            return RedirectToPage();
        }
    }
}

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
    public class ProductModel : PageModel
    {
        /// <summary>
        /// Dependency injection to establish a private connection to a database table by injecting an interface
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IInventory _inventory;
        private readonly IShop _shop;


        /// <summary>
        /// A contructor to set propety to the corresponding interface instance
        /// </summary>
        /// <param name="inventory">IInventory interface</param>
        public ProductModel(IInventory inventory, IShop shop, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _inventory = inventory;
            _shop = shop;
        }

        /// <summary>
        /// A property to be available on the Model property in the Razor Page
        /// </summary>
        public Product SingleProduct { get; set; }

        [BindProperty]
        public ProductInput Input { get; set; }

        /// <summary>
        /// Asynchronous handler method to process the default GET request
        /// </summary>
        /// <returns>A product from the database based on the id</returns>
        public async Task OnGetAsync(int id)
        {
            SingleProduct = await _inventory.GetInventoryByIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = await _shop.GetCartByUserIdAsync(user.Id);
            if (ModelState.IsValid)
            {
                CartItems cartItem = new CartItems
                {
                    CartID = cart.ID,
                    ProductID = id,
                    Quantity = Input.Quantity
                };
                if (await _shop.GetCartItemByProductIdForUserAsync(user.Id, id) != null)
                {
                    CartItems existingCartItem = await _shop.GetCartItemByProductIdForUserAsync(user.Id, id);
                    existingCartItem.Quantity += Input.Quantity;
                    await _shop.UpdateCartItemsAsync(existingCartItem);
                }
                else
                {
                    await _shop.CreateCartItemAsync(cartItem);
                }
            }
            return Redirect("/Shop/Cart");
        }

        public class ProductInput
        {
            public int Quantity { get; set; } = 1;
        }
    }
}
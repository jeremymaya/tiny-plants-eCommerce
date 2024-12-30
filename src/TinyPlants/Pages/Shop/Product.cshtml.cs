using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TinyPlants.Models;
using TinyPlants.Models.Interfaces;

namespace TinyPlants.Pages.Shop
{
    public class ProductModel : PageModel
    {
        /// <summary>
        /// Dependency injection to establish a private connection to a database table by injecting an interface
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IInventoryManager _inventoryManager;
        private readonly IShopManager _shopManager;


        /// <summary>
        /// A contructor to set propety to the corresponding interface instance
        /// </summary>
        /// <param name="inventory">IInventory interface</param>
        public ProductModel(IInventoryManager inventoryManager, IShopManager shopManager, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _inventoryManager = inventoryManager;
            _shopManager = shopManager;
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
            SingleProduct = await _inventoryManager.GetInventoryByIdAsync(id);
        }

        /// <summary>
        /// Create cart items by pulling data information from Product and Cart tables
        /// If the product already exists then call update operation instead of get operation
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Redirect to /Shop/Cart page</returns>
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = await _shopManager.GetCartByUserIdAsync(user.Id);
            if (ModelState.IsValid)
            {
                CartItems cartItem = new CartItems
                {
                    CartId = cart.Id,
                    ProductId = id,
                    Quantity = Input.Quantity
                };
                if (await _shopManager.GetCartItemByProductIdForUserAsync(user.Id, id) != null)
                {
                    CartItems existingCartItem = await _shopManager.GetCartItemByProductIdForUserAsync(user.Id, id);
                    existingCartItem.Quantity += Input.Quantity;
                    await _shopManager.UpdateCartItemsAsync(existingCartItem);
                }
                else
                {
                    await _shopManager.CreateCartItemAsync(cartItem);
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
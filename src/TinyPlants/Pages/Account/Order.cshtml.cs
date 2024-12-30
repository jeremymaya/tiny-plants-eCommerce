using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TinyPlants.Models;
using TinyPlants.Models.Interfaces;

namespace TinyPlants.Pages.Account
{
    public class OrderModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IOrderManager _orderManager;

        /// <summary>
        /// A constructor that brings in SignInManager depdency to be used in the class
        /// </summary>
        /// <param name="signInManager">SignInManager context</param>
        public OrderModel(UserManager<ApplicationUser> userManager, IOrderManager orderManager)
        {
            _userManager = userManager;
            _orderManager = orderManager;
        }

        /// <summary>
        /// A property to be available on the Model property in the Razor Page
        /// </summary>
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<OrderItems> OrderItems { get; set; }

        /// <summary>
        /// Create a user which grab the user id from the database
        /// Then get the user's orders by using user id to look for the corresponding order data
        /// Once gets the user's orders, get the order items that are associated with the orders
        /// </summary>
        /// <returns></returns>
        public async Task OnGetAsync()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            Orders = await _orderManager.GetOrdersByUserIdAsync(user.Id);
            OrderItems = await _orderManager.GetOrderItemsAsync();
        }
    }
}
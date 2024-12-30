using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TinyPlants.Models;
using TinyPlants.Models.Interfaces;

namespace TinyPlants.Pages.Checkout
{
    public class ReceiptModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOrderManager _orderManager;

        /// <summary>
        /// Constructor to take UserManager and IOrder interface
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="order"></param>
        public ReceiptModel(UserManager<ApplicationUser> userManager, IOrderManager orderManager)
        {
            _userManager = userManager;
            _orderManager = orderManager;
        }

        public IList<OrderItems> OrderItems { get; set; }

        /// <summary>
        /// Create a user of type ApplicationUser that gets the user that is currently signed in
        /// Get the orders for the current user by taking the user id
        /// Get all the order items by the order id
        /// </summary>
        /// <returns></returns>
        public async Task OnGetAsync()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            Order order = await _orderManager.GetLatestOrderForUserAsync(user.Id);
            OrderItems = await _orderManager.GetOrderItemsByOrderIdAsync(order.Id);
        }
    }
}
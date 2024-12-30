using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TinyPlants.Models;
using TinyPlants.Models.Interfaces;

namespace TinyPlants.Pages.Account
{
    public class DetailsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IOrderManager _orderManager;

        /// <summary>
        /// A constructor that brings in UserManager<ApplicationUser> and IOrder interface to enable the implementation of show the order details that contains only the user's orders
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="order"></param>
        public DetailsModel(UserManager<ApplicationUser> userManager, IOrderManager orderManager)
        {
            _userManager = userManager;
            _orderManager = orderManager;
        }

        /// <summary>
        /// A property to be available on the Model property in the Razor Page
        /// </summary>
        public IEnumerable<OrderItems> OrderItems { get; set; }

        /// <summary>
        /// Get all the order items by sending over the order id that is requested
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task OnGetAsync(int id)
        {
            OrderItems = await _orderManager.GetOrderItemsByOrderIdAsync(id);
        }
    }
}
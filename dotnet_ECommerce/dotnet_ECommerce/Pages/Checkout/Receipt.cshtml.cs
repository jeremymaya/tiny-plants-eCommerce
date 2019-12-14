using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ECommerce.Models;
using dotnet_ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet_ECommerce.Pages.Checkout
{
    public class ReceiptModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOrder _order;

        /// <summary>
        /// Constructor to take UserManager and IOrder interface
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="order"></param>
        public ReceiptModel(UserManager<ApplicationUser> userManager, IOrder order)
        {
            _userManager = userManager;
            _order = order;
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
            Order order = await _order.GetLatestOrderForUserAsync(user.Id);
            OrderItems = await _order.GetOrderItemsByOrderIdAsync(order.ID);
        }
    }
}
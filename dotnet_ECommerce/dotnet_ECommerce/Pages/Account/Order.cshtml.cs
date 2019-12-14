using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ECommerce.Models;
using dotnet_ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace dotnet_ECommerce.Pages.Account
{
    public class OrderModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IOrder _order;

        /// <summary>
        /// A constructor that brings in SignInManager depdency to be used in the class
        /// </summary>
        /// <param name="signInManager">SignInManager context</param>
        public OrderModel(UserManager<ApplicationUser> userManager, IOrder order)
        {
            _userManager = userManager;
            _order = order;
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
            Orders = await _order.GetOrdersByUserIdAsync(user.Id);
            OrderItems = await _order.GetOrderItemsAsync();
        }
    }
}
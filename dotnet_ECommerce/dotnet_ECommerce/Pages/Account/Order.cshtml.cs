using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ECommerce.Models;
using dotnet_ECommerce.Models.Interfaces;
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
        /// A property that brings in SignInManager depdency to be used in the class
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

        public async Task OnGetAsync()
        {
            Orders = await _order.GetOrdersAsync();
            OrderItems = await _order.GetOrderItemsAsync();
        }
    }
}
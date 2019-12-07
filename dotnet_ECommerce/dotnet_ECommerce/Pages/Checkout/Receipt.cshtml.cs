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

        public ReceiptModel(UserManager<ApplicationUser> userManager, IOrder order)
        {
            _userManager = userManager;
            _order = order;
        }

        public IList<OrderItems> OrderItems { get; set; }

        public async Task OnGetAsync()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            Order order = await _order.GetLatestOrderForUserAsync(user.Id);
            OrderItems = await _order.GetOrderItemsByOrderIdAsync(order.ID);
        }
    }
}
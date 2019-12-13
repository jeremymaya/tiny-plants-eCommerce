using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ECommerce.Models;
using dotnet_ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet_ECommerce.Pages.Account
{
    public class DetailsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IOrder _order;

        public DetailsModel(UserManager<ApplicationUser> userManager, IOrder order)
        {
            _userManager = userManager;
            _order = order;
        }

        public IEnumerable<OrderItems> OrderItems { get; set; }

        public async Task OnGetAsync(int id)
        {
            OrderItems = await _order.GetOrderItemsByOrderIdAsync(id);
        }
    }
}
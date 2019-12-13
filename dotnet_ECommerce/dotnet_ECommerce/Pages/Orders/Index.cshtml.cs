using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ECommerce.Models;
using dotnet_ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet_ECommerce.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly IOrder _order;

        public IndexModel(IOrder order)
        {
            _order = order;
        }

        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<OrderItems> OrderItems { get; set; }

        public async Task OnGetAsync()
        {
            Orders = await _order.GetOrdersAsync();
            OrderItems = await _order.GetOrderItemsAsync();
        }
    }
}

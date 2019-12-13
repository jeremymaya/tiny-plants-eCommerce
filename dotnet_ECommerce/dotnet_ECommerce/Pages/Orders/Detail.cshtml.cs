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
    public class DetailModel : PageModel
    {
        private readonly IOrder _order;

        public DetailModel(IOrder order)
        {
            _order = order;
        }

        public IEnumerable<OrderItems> OrderItems { get; set;}

        public async Task OnGetAsync(int id)
        {
            OrderItems = await _order.GetOrderItemsByOrderIdAsync(id);
        }
    }
}

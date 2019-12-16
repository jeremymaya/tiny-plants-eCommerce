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

        /// <summary>
        /// The constructor to bring in IOrder interface that enables getting information from the order data table
        /// </summary>
        /// <param name="order"></param>
        public IndexModel(IOrder order)
        {
            _order = order;
        }

        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<OrderItems> OrderItems { get; set; }

        /// <summary>
        /// Get all the orders from the order table
        /// Get all the order items from the each order
        /// </summary>
        /// <returns></returns>
        public async Task OnGetAsync()
        {
            Orders = await _order.GetOrdersAsync();
            OrderItems = await _order.GetOrderItemsAsync();
        }
    }
}

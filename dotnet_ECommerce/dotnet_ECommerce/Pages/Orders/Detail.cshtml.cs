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
        // Bring in IOrder interface to enable the implementation
        private readonly IOrder _order;

        public DetailModel(IOrder order)
        {
            _order = order;
        }

        // Get the Order Items from the database and store in OrderItems with a data type of IEnumerable<OrderItems>
        public IEnumerable<OrderItems> OrderItems { get; set;}

        /// <summary>
        /// Get all the order items details by the order id that is selected
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task OnGetAsync(int id)
        {
            OrderItems = await _order.GetOrderItemsByOrderIdAsync(id);
        }
    }
}

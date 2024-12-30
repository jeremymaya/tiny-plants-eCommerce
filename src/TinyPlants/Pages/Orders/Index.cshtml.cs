using Microsoft.AspNetCore.Mvc.RazorPages;
using TinyPlants.Models;
using TinyPlants.Models.Interfaces;

namespace TinyPlants.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly IOrderManager _orderManager;

        /// <summary>
        /// The constructor to bring in IOrder interface that enables getting information from the order data table
        /// </summary>
        /// <param name="order"></param>
        public IndexModel(IOrderManager orderManager)
        {
            _orderManager = orderManager;
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
            Orders = await _orderManager.GetOrdersAsync();
            OrderItems = await _orderManager.GetOrderItemsAsync();
        }
    }
}

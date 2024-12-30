using Microsoft.AspNetCore.Mvc.RazorPages;
using TinyPlants.Models;
using TinyPlants.Models.Interfaces;

namespace TinyPlants.Pages.Orders
{
    public class DetailModel : PageModel
    {
        // Bring in IOrder interface to enable the implementation
        private readonly IOrderManager _orderManager;

        public DetailModel(IOrderManager orderManager)
        {
            _orderManager = orderManager;
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
            OrderItems = await _orderManager.GetOrderItemsByOrderIdAsync(id);
        }
    }
}

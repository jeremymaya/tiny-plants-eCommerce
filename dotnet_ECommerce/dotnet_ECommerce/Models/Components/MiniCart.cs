using System;
using System.Threading.Tasks;
using dotnet_ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_ECommerce.Models.Components
{
    public class MiniCart : ViewComponent
    {
        private readonly IInventory _inventory;

        public MiniCart(IInventory inventory)
        {
            _inventory = inventory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int number)
        {
            var cartItems = _inventory.
            return View(posts);
            // return View("nameofThing")
        }
    }
}

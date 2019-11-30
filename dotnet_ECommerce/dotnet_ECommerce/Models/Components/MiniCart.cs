using System;
using System.Threading.Tasks;
using dotnet_ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_ECommerce.Models.Components
{
    public class MiniCart : ViewComponent
    {
        private readonly IShop _shop;

        public MiniCart(IShop shop)
        {
            _shop = shop;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cartItems = await _shop.GetCartItemsAsync();

            return View(cartItems);
        }
    }
}

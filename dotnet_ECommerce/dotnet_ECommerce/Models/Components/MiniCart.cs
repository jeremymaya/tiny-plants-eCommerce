using System;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_ECommerce.Models.Components
{
    public class MiniCart : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IShop _shop;

        public MiniCart(UserManager<ApplicationUser> userManager, IShop shop)
        {
            _userManager = userManager;
            _shop = shop;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cartItems = await _shop.GetCartItemsAsync();

            return View(cartItems);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_ECommerce.Models.Components
{
    /// <summary>
    /// The MiniCartViewComponent class inherits ViewComponent class then brings in dependencies
    /// The InvokeAsync method utilizes UserManager to bring in the user and call GetUserId to access the user id
    /// A variable is created to store all the cart items of the user by calling GetCartItemsByUserIdAsync that takes an user id and returns all the cart items where the items' user id matches.

    /// </summary>
    public class MiniCartViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IShop _shop;

        public MiniCartViewComponent(UserManager<ApplicationUser> userManager, IShop shop)
        {
            _userManager = userManager;
            _shop = shop;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = _userManager.GetUserId((System.Security.Claims.ClaimsPrincipal)User);
            var cartItems = await _shop.GetCartItemsByUserIdAsync(userId);

            return View(cartItems);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ECommerce.Models;
using dotnet_ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet_ECommerce.Pages.Shop
{
    public class CartModel : PageModel
    {
        /// <summary>
        /// Dependency injection to establish a private connection to a database table by injecting an interface
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IInventory _inventory;
        private readonly IShop _shop;

        /// <summary>
        /// A contructor to set propety to the corresponding interface instance
        /// </summary>
        /// <param name="inventory">IInventory interface</param>
        public CartModel(IInventory inventory, IShop shop, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _inventory = inventory;
            _shop = shop;
        }

        public void OnGet()
        {
        }
    }
}

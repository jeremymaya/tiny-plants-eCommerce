using System;
using dotnet_ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_ECommerce.Models.Components
{
    public class MiniCart : ViewComponent
    {
        private IInventory _inventory;

        public MiniCart(IInventory inventory)
        {
            _inventory = inventory;
        }


    }
}

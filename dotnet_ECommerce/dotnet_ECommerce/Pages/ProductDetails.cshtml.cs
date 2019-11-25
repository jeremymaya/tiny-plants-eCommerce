using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ECommerce.Models;
using dotnet_ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace dotnet_ECommerce.Pages
{
    public class ProductDetailsModel : PageModel
    {
        private readonly IInventory _context;

        public ProductDetailsModel(IInventory context)
        {
            _context = context;
        }

        public Product SingleProduct { get; set; }

        public async Task OnGetAsync(int id)
        {
            SingleProduct = await _context.GetInventoryByIdAsync(id);
        }
    }
}

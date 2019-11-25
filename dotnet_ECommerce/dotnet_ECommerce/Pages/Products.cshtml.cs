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
    public class ProductsModel : PageModel
    {
        private readonly IInventory _context;

        public ProductsModel(IInventory context)
        {
            _context = context;
        }

        public IList<Product> Products { get; set; }

        public Product Product { get; set; }

        public async Task OnGetAsync()
        {
            Products = await _context.GetAllInventoriesAsync();
        }
    }
}

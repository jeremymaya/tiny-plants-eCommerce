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
    public class IndexModel : PageModel
    {
        private readonly IInventory _context;

        public IndexModel(IInventory context)
        {
            _context = context;
        }

        public IList<Product> FeaturedProducts { get; set; }

        public async Task OnGetAsync()
        {
            FeaturedProducts = await _context.GetFeaturedInventoriesAsync();
        }
    }
}
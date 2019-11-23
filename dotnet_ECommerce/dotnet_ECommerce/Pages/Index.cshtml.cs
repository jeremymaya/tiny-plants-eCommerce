using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace dotnet_ECommerce.Pages
{
    public class IndexModel : PageModel
    {
        private readonly dotnet_ECommerce.Data.StoreDbContext _context;

        public IndexModel (dotnet_ECommerce.Data.StoreDbContext context)
        {
            _context = context;
        }

        public IList<Product> FeaturedProducts { get; set; }

        public async Task OnGetAsync()
        {
            FeaturedProducts = await _context.Product.ToListAsync();
        }
    }
}
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
    public class ProductsModel : PageModel
    {
        private readonly dotnet_ECommerce.Data.StoreDbContext _context;

        public ProductsModel(dotnet_ECommerce.Data.StoreDbContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get; set; }

        public async Task OnGetAsync()
        {
            Products = await _context.Product
                .ToListAsync();
        }
    }
}

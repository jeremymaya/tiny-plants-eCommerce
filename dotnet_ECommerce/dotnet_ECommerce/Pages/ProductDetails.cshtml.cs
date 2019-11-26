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
        /// <summary>
        /// Dependency injection to establish a private connection to a database table by injecting an interface
        /// </summary>
        private readonly IInventory _context;

        /// <summary>
        /// A contructor to set propety to the corresponding interface instance
        /// </summary>
        /// <param name="context">IInventory interface</param>
        public ProductDetailsModel(IInventory context)
        {
            _context = context;
        }

        /// <summary>
        /// A property to be available on the Model property in the Razor Page
        /// </summary>
        public Product SingleProduct { get; set; }

        /// <summary>
        /// Asynchronous handler method to process the default GET request
        /// </summary>
        /// <returns>A product from the database based on the id</returns>
        public async Task OnGetAsync(int id)
        {
            SingleProduct = await _context.GetInventoryByIdAsync(id);
        }
    }
}

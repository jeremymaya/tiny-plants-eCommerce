using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ECommerce.Models;
using dotnet_ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_ECommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly IInventory _context;

        public ProductController(IInventory inventory)
        {
            _context = inventory;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAllInventoriesAsync());
        }

        // GET: Products/Detail/5
        public async Task<IActionResult> Details(int id)
        {
            if(id <= 0)
            {
                return NotFound();
            }

            Product product = await _context.GetInventoryByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


    }
}
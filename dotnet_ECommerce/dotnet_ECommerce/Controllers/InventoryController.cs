using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ECommerce.Models;
using dotnet_ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet_ECommerce.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventory _context;

        public InventoryController(IInventory inventory)
        {
            _context = inventory;
        }

        // GET: Products
        /// <summary>
        /// Default HTTP GET route for /Products to display all of the product data from the connencted database
        /// </summary>
        /// <returns>Index.cshtml with all of product data from the connected database</returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAllInventoriesAsync());
        }

        // GET: Products/Detail/5
        /// <summary>
        /// HTTP GET route for Products/Edit to get a product data based on the product Id from the connencted database
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>Edit.cshtml with product data that matches with the id from the conntected database</returns>
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
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

        // POST: Products/Create
        /// <summary>
        /// HTTP POST route doe Products/Create to create a new product data by saving a Product object into the connected database
        /// </summary>
        /// <param name="product">New product information</param>
        /// <returns>Index.cshtml with the updated products list from the the conntected database</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Sku,Name,Price,Description,Image")] Product product)
        {
            if (ModelState.IsValid)
            {
                await _context.CreateInventoryAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        /// <summary>
        /// HTTP GET route for Products/Edit to get a product data based on the product Id from the connected database
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>Edit.cshtml with a product infomration based on the product Id from the connected database</returns>
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var product = await _context.GetInventoryByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        //POST: Products/Edit/5
        /// <summary>
        /// HTTP POST route for Products/Edit/ to edit the product data from the connected database
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <param name="product">Product data based on the Id</param>
        /// <returns>Index.cshtml with the updated products list from the the conntected database</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Sku,Name,Price,Description,Image")] Product product)
        {
            if (id != product.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateInventoryAsync(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ProductExists(product.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        /// <summary>
        /// HTTP GET route for Products/Delete/ to get a product data based on the product Id to be deleted from the connected database
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>Delete.cshtml with a product data based on the product Id</returns>
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var product = await _context.GetInventoryByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        /// <summary>
        /// HTTP POST route for Products/Delete/ to delete a product data based on the producrt Id from the connected database
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>Index.cshtml with the updated products list from the the conntected database</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            await _context.RemoveInventoryAsync(id);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// An action that checks if a product data exists based on the product Id in the connected database
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>Boolean value which confirms if a produuct data based on the product Id exists</returns>
        private async Task<bool> ProductExists(int id)
        {
            Product product = await _context.GetInventoryByIdAsync(id);
            if (product != null)
            {
                return true;
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ECommerce.Models;
using dotnet_ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_ECommerce.Controllers
{
    public class ProductController : Controller
    {
        //private readonly IInventory _context;

        //public ProductController(IInventory inventory)
        //{
        //    _context = inventory;
        //}

        //// GET: Products
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.GetAllInventoriesAsync());
        //}

        //// GET: Products/Detail/5
        //public async Task<IActionResult> Details(int id)
        //{
        //    if (id <= 0)
        //    {
        //        return NotFound();
        //    }

        //    Product product = await _context.GetInventoryByIdAsync(id);

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}

        //// POST: Products/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,Sku,Name,Price,Description,Image")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _context.CreateInventoryAsync(product);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(product);
        //}

        //// GET: Products/Edit/5
        //public async Task<IActionResult> Edit(int id)
        //{
        //    if (id <= 0)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.GetInventoryByIdAsync(id);

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(product);
        //}

        ////POST: Products/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,Sku,Name,Price,Description,Image")] Product product)
        //{
        //    if (id != product.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            await _context.UpdateInventoryAsync(product);
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!await ProductExists(product.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(product);
        //}

        //// GET: Products/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    await _context.RemoveInventoryAsync(id);
        //    return RedirectToAction(nameof(Index));
        //}

        //private async Task<bool> ProductExists(int id)
        //{
        //    Product product = await _context.GetInventoryByIdAsync(id);
        //    if (product != null)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}
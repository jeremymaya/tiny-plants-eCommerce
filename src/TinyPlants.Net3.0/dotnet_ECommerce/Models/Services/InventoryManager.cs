using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ECommerce.Data;
using dotnet_ECommerce.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace dotnet_ECommerce.Models.Services
{
    public class InventoryManager : IInventoryManager
    {
        /// <summary>
        /// Establishes a private connection to a database via dependency injection
        /// </summary>
        private StoreDbContext _context;

        public InventoryManager(StoreDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a product data by saving a Product object into the connected database
        /// </summary>
        /// <param name="product">New product information</param>
        /// <returns>Void</returns>
        public async Task CreateInventoryAsync(Product product)
        {
            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all of the product data from the connencted database
        /// </summary>
        /// <returns>IList of all products from the connected database</returns>
        public async Task<IList<Product>> GetAllInventoriesAsync() => await _context.Product.ToListAsync();

        /// <summary>
        /// Gets all of the entries from the connctected database
        /// </summary>
        /// <returns>IList of all product data marked as IsFeatured from the conntected database</returns>
        public async Task<IList<Product>> GetFeaturedInventoriesAsync() => await _context.Product
                .Where(x => x.IsFeatured == true)
                .ToListAsync();

        /// <summary>
        /// Gets a product data based on the id from the connencted database
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>Product data that matches with the id from the conntected database</returns>
        public async Task<Product> GetInventoryByIdAsync(int id) => await _context.Product.FindAsync(id);

        /// <summary>
        /// Deletes a product data based on the id from the connected database
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>Void</returns>
        public async Task RemoveInventoryAsync(int id)
        {
            var product = await GetInventoryByIdAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Modifies a product data from the connected database
        /// </summary>
        /// <param name="product">Modified product information</param>
        /// <returns>Void</returns>
        public async Task UpdateInventoryAsync(Product product)
        {
            _context.Product.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_ECommerce.Models.Interfaces.Services
{
    public class ProductService : IInventory
    {
        //private StoreDbContext _context;

        //public ProductService(StoreDbContext _context)
        //{
        //    _context = context;
        //}
        //public async Task CreateInventoryAsync(Product product)
        //{
        //    await _context.Product.AddAsync(product);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task<List<Product>> GetAllInventoriesAsync() => await _context.Posts.ToListAsync();

        //public async Task<Product> GetInventoryByIdAsync(int id) => await _context.Posts.FindAsync(id);

        //public async Task RemoveInventoryAsync(int id)
        //{
        //    var product = await GetInventoryByIdAsync(id);
        //    _context.Product.Remove(product);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task UpdateInventoryAsync(Product product)
        //{
        //    _context.Posts.Update(product);
        //    await _context.SaveChangesAsync();
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_ECommerce.Models.Interfaces.Services
{
    public class ProductService : IInventory
    {
        private StoreDbContext _context;

        public ProductService(StoreDbContext _context)
        {
            _context = context;
        }
        public async Task CreateInventoryAsync(Product product)
        {
            _context.Posts.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetProductsAsync() => await _context.Posts.ToListAsync();

        public async Task<Product> GetProductById(int id) => await _context.Posts.FindAsync(id);

        public async Task RemoveProductAsync(int id)
        {
            var product = await GetProductById(id);
            _context.Posts.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.Posts.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}

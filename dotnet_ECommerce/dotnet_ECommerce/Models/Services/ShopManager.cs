using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_ECommerce.Data;
using dotnet_ECommerce.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace dotnet_ECommerce.Models.Services
{
    public class ShopManager : IShop
    {
        private readonly StoreDbContext _context;

        public ShopManager(StoreDbContext context)
        {
            _context = context;
        }

        public async Task CreateCartAsync(Cart cart)
        {
            await _context.Cart.AddAsync(cart);
            await _context.SaveChangesAsync();
        }

        public async Task<CartItems> GetCartItemByIdAsync(int id) => await _context.CartItems.FindAsync(id);

        public async Task<IEnumerable<CartItems>> GetCartItemsAsync() => await _context.CartItems.ToListAsync();

        public async Task RemoveCartItemsAsync(int id)
        {
            CartItems cartItem = await GetCartItemByIdAsync(id);
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCartItemsAsync(CartItems cartItems)
        {
            _context.CartItems.Update(cartItems);
            await _context.SaveChangesAsync();
        }
    }
}

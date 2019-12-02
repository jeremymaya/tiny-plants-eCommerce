using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task CreateCartItemAsync(CartItems cartItems)
        {
            await _context.CartItems.AddAsync(cartItems);
            await _context.SaveChangesAsync();
        }

        public async Task<Cart> GetCartByUserIdAsync(string userId) => await _context.Cart.FirstOrDefaultAsync(cart => cart.UserID == userId);

        public async Task<IEnumerable<CartItems>> GetCartItemsByUserIdAsync(string userId)
        {
            Cart cart = await GetCartByUserIdAsync(userId);
            return _context.CartItems.Where(cartItem => cartItem.CartID == cart.ID).Include(x => x.Product);
        }

        public async Task<CartItems> GetCartItemByIdlAsync(int id) => await _context.CartItems.FirstOrDefaultAsync(cart => cart.ID == id);

        public async Task RemoveCartItemsAsync(int id)
        {
            CartItems cartItem = await GetCartItemByIdlAsync(id);
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

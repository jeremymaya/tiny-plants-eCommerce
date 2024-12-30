using Microsoft.EntityFrameworkCore;
using TinyPlants.Data;
using TinyPlants.Models.Interfaces;

namespace TinyPlants.Models.Services;

public class ShopManager : IShopManager
{
    /// <summary>
    /// Establishes a private connection to a database via dependency injection
    /// </summary>
    private readonly StoreDbContext _context;

    public ShopManager(StoreDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Saves a cart data by saving an Cart object into the connected database
    /// </summary>
    /// <param name="cart">New cart information</param>
    /// <returns>Void</returns>
    public async Task CreateCartAsync(Cart cart)
    {
        await _context.Cart.AddAsync(cart);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Saves a cartItenm data by saving an CartItems object into the connected database
    /// </summary>
    /// <param name="cartItems">New cartItem information</param>
    /// <returns>Void</returns>
    public async Task CreateCartItemAsync(CartItems cartItems)
    {
        await _context.CartItems.AddAsync(cartItems);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Gets a cart data based on the userId from the connected database
    /// </summary>
    /// <param name="userId">User Id</param>
    /// <returns>Cart data that matches with the userId from the connected database</returns>
    public async Task<Cart> GetCartByUserIdAsync(string userId) => await _context.Cart.FirstOrDefaultAsync(cart => cart.UserId == userId);

    /// <summary>
    /// Gets all of the cartItems data based on the userId from the connected database
    /// </summary>
    /// <param name="userId">User Id</param>
    /// <returns>IEnumerable of cartItems that matches with userId from the connected database</returns>
    public async Task<IEnumerable<CartItems>> GetCartItemsByUserIdAsync(string userId)
    {
        Cart cart = await GetCartByUserIdAsync(userId);
        return _context.CartItems.Where(cartItem => cartItem.CartId == cart.Id).Include(x => x.Product);
    }

    /// <summary>
    /// Gets a cartItem data based on the userId and productId from the connected database
    /// </summary>
    /// <param name="userId">User Id</param>
    /// <param name="productId">Product Id</param>
    /// <returns>CartItems data that matches with the userId and productId from the connected database</returns>
    public async Task<CartItems> GetCartItemByProductIdForUserAsync(string userId, int productId)
    {
        var cartItems = await GetCartItemsByUserIdAsync(userId);
        return cartItems.FirstOrDefault(cart => cart.ProductId == productId);
    }

    /// <summary>
    /// Deletes a cartItem data based on the userId and productId from the connected database
    /// </summary>
    /// <param name="userId">User Id</param>
    /// <param name="productId">Product Id</param>
    /// <returns>Void</returns>
    public async Task RemoveCartItemsAsync(string userId, int productId)
    {
        CartItems cartItem = await GetCartItemByProductIdForUserAsync(userId, productId);
        _context.CartItems.Remove(cartItem);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes a collection of cartItems data from the connected database
    /// </summary>
    /// <param name="cartItems">IEnumerable of cartItems</param>
    /// <returns>Void</returns>
    public async Task RemoveCartItemsAsync(IEnumerable<CartItems> cartItems)
    {
        _context.CartItems.RemoveRange(cartItems);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Modifies an cartItem data from the connected database
    /// </summary>
    /// <param name="cartItem">Modified cartItem information</param>
    /// <returns>Void</returns>
    public async Task UpdateCartItemsAsync(CartItems cartItem)
    {
        _context.CartItems.Update(cartItem);
        await _context.SaveChangesAsync();
    }
}

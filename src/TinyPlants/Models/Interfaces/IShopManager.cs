using System;

namespace TinyPlants.Models.Interfaces;

public interface IShopManager
{
    Task CreateCartAsync(Cart cart);

    Task CreateCartItemAsync(CartItems cartItems);

    Task<Cart> GetCartByUserIdAsync(string userId);

    Task<IEnumerable<CartItems>> GetCartItemsByUserIdAsync(string userId);

    Task<CartItems> GetCartItemByProductIdForUserAsync(string userId, int productId);

    Task UpdateCartItemsAsync(CartItems cartItems);

    Task RemoveCartItemsAsync(string userId, int productId);

    Task RemoveCartItemsAsync(IEnumerable<CartItems> cartItems);
}

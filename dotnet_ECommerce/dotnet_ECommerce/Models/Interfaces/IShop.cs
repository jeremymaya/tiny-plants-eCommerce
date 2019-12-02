using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_ECommerce.Models.Interfaces
{
    public interface IShop
    {
        Task CreateCartAsync(Cart cart);

        Task CreateCartItemAsync(CartItems cartItems);

        Task<Cart> GetCartByUserIdAsync(string userId);

        Task<IEnumerable<CartItems>> GetCartItemsByUserIdAsync(string userId);

        Task<CartItems> GetCartItemByProductIdForUserAsync(string userId, int productId);

        Task UpdateCartItemsAsync(CartItems cartItems);

        Task RemoveCartItemsAsync(string userId, int productId);
    }
}

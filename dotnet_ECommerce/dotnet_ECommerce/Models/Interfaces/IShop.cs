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

        Task<IEnumerable<Cart>> GetCartsAsync();

        Task<IEnumerable<CartItems>> GetCartItemsByUserIdAsync(string userId);

        Task<CartItems> GetCartItemByIdlAsync(int id);

        Task RemoveCartItemsAsync(int id);

        Task UpdateCartItemsAsync(CartItems cartItems);
    }
}

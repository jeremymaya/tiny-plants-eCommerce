using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_ECommerce.Models.Interfaces
{
    public interface IShop
    {
        Task CreateCartAsync(Cart cart);

        Task<IEnumerable<CartItems>> GetCartItemsAsync();

        Task<CartItems> GetCartItemByIdAsync(int id);

        Task UpdateCartItemsAsync(CartItems cartItems);

        Task RemoveCartItemsAsync(int id);
    }
}

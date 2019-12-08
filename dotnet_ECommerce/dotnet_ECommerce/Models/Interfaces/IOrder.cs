using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_ECommerce.Models.Interfaces
{
    public interface IOrder
    {
        Task SaveOrderAsync(Order order);

        Task<Order> GetLatestOrderForUserAsync(string userId);

        Task SaveOrderItemAsync(OrderItems orderItem);

        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId);

        Task<IList<OrderItems>> GetOrderItemsByOrderIdAsync(int orderId);

        Task UpdateOrderItemsAsync(OrderItems orderItems);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_ECommerce.Models.Interfaces
{
    public interface IOrder
    {
        Task CreateOrderAsync(Order order);

        Task CreateOrderItemAsync(OrderItems orderItems);

        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId);

        Task<IEnumerable<OrderItems>> GetOrderItemsByOrderIdAsync(int orderId);

        Task UpdateOrderItemsAsync(OrderItems orderItems);
    }
}

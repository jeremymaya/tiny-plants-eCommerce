using System;

namespace TinyPlants.Models.Interfaces;

public interface IOrderManager
{
    Task SaveOrderAsync(Order order);

    Task<Order> GetLatestOrderForUserAsync(string userId);

    Task SaveOrderItemAsync(OrderItems orderItem);

    Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId);

    Task<IEnumerable<Order>> GetOrdersAsync();

    Task<IList<OrderItems>> GetOrderItemsByOrderIdAsync(int orderId);

    Task<IEnumerable<OrderItems>> GetOrderItemsAsync();

    Task UpdateOrderItemsAsync(OrderItems orderItems);
}

using Microsoft.EntityFrameworkCore;
using TinyPlants.Data;
using TinyPlants.Models.Interfaces;

namespace TinyPlants.Models.Services;

public class OrderManager : IOrderManager
{
    /// <summary>
    /// Establishes a private connection to a database via dependency injection
    /// </summary>
    private readonly StoreDbContext _context;

    public OrderManager(StoreDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Saves an order data by saving an Order object into the connected database
    /// </summary>
    /// <param name="order">New order information</param>
    /// <returns>Void</returns>
    public async Task SaveOrderAsync(Order order)
    {
        await _context.Order.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Gets the latest order data from the connencted database
    /// </summary>
    /// <param name="userId">User Id</param>
    /// <returns>The lastest order for a user data from the conntected database</returns>
    public async Task<Order> GetLatestOrderForUserAsync(string userId)
    {
        var orders = await GetOrdersByUserIdAsync(userId);
        return orders.OrderByDescending(order => order.Id).FirstOrDefault();
    }

    /// <summary>
    /// Saves an orderItems data by saving an orderItems object into the connected database
    /// </summary>
    /// <param name="orderItem">New orderItems information</param>
    /// <returns>Void</returns>
    public async Task SaveOrderItemAsync(OrderItems orderItem)
    {
        await _context.OrderItems.AddAsync(orderItem);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Gets all of the oder data for a user from the connencted database
    /// </summary>
    /// <param name="userId">User Id</param>
    /// <returns>IEnumerable of all order data marked for the user from the conntected database</returns>
    public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId) => await _context.Order.Where(order => order.UserId == userId).ToListAsync();

    public async Task<IEnumerable<Order>> GetOrdersAsync() => await _context.Order.ToListAsync();

    /// <summary>
    /// Gets all of the oderItems data for an orderId from the connencted database
    /// </summary>
    /// <param name="orderId"></param>
    /// <returns>IList of all orderItems data for the orderId fron the connected database</returns>
    public async Task<IList<OrderItems>> GetOrderItemsByOrderIdAsync(int orderId) => await _context.OrderItems.Where(orderItems => orderItems.OrderId == orderId).Include(x => x.Product).ToListAsync();

    public async Task<IEnumerable<OrderItems>> GetOrderItemsAsync() => await _context.OrderItems.Include(x => x.Product).ToListAsync();

    /// <summary>
    /// Modifies an orderItem data from the connected database
    /// </summary>
    /// <param name="orderItem">Modified orderItem information</param>
    /// <returns>Void</returns>
    public async Task UpdateOrderItemsAsync(OrderItems orderItem)
    {
        _context.OrderItems.Update(orderItem);
        await _context.SaveChangesAsync();
    }
}

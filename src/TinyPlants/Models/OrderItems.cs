namespace TinyPlants.Models;

public class OrderItems
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    /// <summary>
    /// Navigational Properties
    /// </summary>
    public Order Order { get; set; }

    public Product Product { get; set; }
}

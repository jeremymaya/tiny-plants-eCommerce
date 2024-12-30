using System.ComponentModel.DataAnnotations;

namespace TinyPlants.Models;

public class CartItems
{
    public int Id { get; set; }

    public int CartId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    // Navigational Properties
    [Required]
    public Cart Cart { get; set; } = null!;

    [Required]
    public Product Product { get; set; } = null!;
}

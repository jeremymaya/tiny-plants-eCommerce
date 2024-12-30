using System.ComponentModel.DataAnnotations;

namespace TinyPlants.Models;

public class Cart
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;
}

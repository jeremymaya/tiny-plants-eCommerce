using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TinyPlants.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Sku { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public decimal Price { get; set; }

    [Required]
    public string Description { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;

    [Required]
    public bool IsFeatured { get; set; }

    [NotMapped]
    public IFormFile? File { get; set; }
}

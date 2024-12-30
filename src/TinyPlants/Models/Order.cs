using System.ComponentModel.DataAnnotations;

namespace TinyPlants.Models;

public class Order
{
    public int Id { get; set; }

    public string UserId { get; set; } = string.Empty;

    [Display(Name = "First Name")]
    public string FirstName { get; set; } = string.Empty;

    [Display(Name = "Last Name")]
    public string LastName { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    [Display(Name = "Address 2")]
    public string Address2 { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string State { get; set; } = string.Empty;

    public string Zip { get; set; } = string.Empty;

    public string CreditCard { get; set; } = string.Empty;

    public string Timestamp { get; set; } = string.Empty;
}

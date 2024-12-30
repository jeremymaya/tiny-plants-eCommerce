using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TinyPlants.Models;

/// <summary>
/// ApplicationUser class that extends IdentityUser
/// </summary>
public class ApplicationUser : IdentityUser
{
    [Required]
    [Display(Name = "First Name")]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Last Name")]
    public string LastName { get; set;} = string.Empty;

    [Required]
    public string Address { get; set; } = string.Empty;

    [Display(Name = "Address 2")]
    public string? Address2 { get; set; }

    [Required]
    public string City { get; set; } = string.Empty;

    [Required]
    public string State { get; set; } = string.Empty;

    [Required]
    public string Zip { get; set; } = string.Empty;
}

/// <summary>
///  Create new roles
/// </summary>
public static class ApplicationRoles
{
    public const string Member = "Member";
    public const string Admin = "Administration";
}

using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace dotnet_ECommerce.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Address { get; set; }

        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }
    }

    /// <summary>
    /// Create new roles
    /// </summary>
    public static class ApplicationRoles
    {
        public const string Member = "Member";
        public const string Admin = "Administration";
    }
}

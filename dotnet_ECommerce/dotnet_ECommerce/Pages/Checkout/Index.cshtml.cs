using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet_ECommerce.Pages.Checkout
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public CheckoutInput Input { get; set; }

        public void OnGet()
        {
        }

        public class CheckoutInput
        {
            [Required]
            [Display(Name = "First Name:")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name:")]
            public string LastName { get; set; }

            [Required]
            public string Address { get; set; }

            [Display(Name = "Address 2:")]
            public string Address2 { get; set; }

            [Required]
            public string City { get; set; }

            [Required]
            public string State { get; set; }

            [Required]
            [DataType(DataType.PostalCode)]
            [Compare("Zip", ErrorMessage = "The is an invalid zip code")]
            public string Zip { get; set; }
        }
    }
}

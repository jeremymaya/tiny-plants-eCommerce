using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ECommerce.Models;
using dotnet_ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static dotnet_ECommerce.Pages.Checkout.IndexModel;

namespace dotnet_ECommerce.Pages.Checkout
{
    public class ReceiptModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IShop _shop;
        private readonly IPayment _paymnet;

        public ReceiptModel(UserManager<ApplicationUser> userManager, IShop shop, IPayment payment)
        {
            _userManager = userManager;
            _shop = shop;
            _paymnet = payment;
        }

        [BindProperty]
        public ReceiptInfo CheckOut { get; set; }

        public async Task<IActionResult> OnGet()
        {
            return Page();
        }

        public class ReceiptInfo
        {
            [Display(Name = "Purchased Date:")]
            public string Date { get; set; }

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

            [Required]
            public string Email { get; set; }

            [Required]
            public CreditCard CreditCard { get; set; }
        }
    }
}
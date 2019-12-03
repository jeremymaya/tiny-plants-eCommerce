using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ECommerce.Models;
using dotnet_ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet_ECommerce.Pages.Checkout
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly IShop _shop;

        public IndexModel(UserManager<ApplicationUser> userManager, IEmailSender emailSender, IShop shop)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _shop = shop;
        }

        [BindProperty]
        public CheckoutInput Input { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            decimal total = 0;

            IEnumerable<CartItems> cartItems = await _shop.GetCartItemsByUserIdAsync(user.Id);
            foreach (var cartItem in cartItems)
            {
                total += (cartItem.Product.Price * cartItem.Quantity);
            }

            string subject = "Purhcase Summary From Tiny Plants!";
            string message =
                $"<p>Hello {user.FirstName} {user.LastName},</p>" +
                $"<p>&nbsp;</p>" +
                $"<p>Below is your recent purchase summary</p>" +
                $"<p>Total: ${ total }\n</p>" + "<a href=\"https://dotnet-ecommerce-tiny-plants.azurewebsites.net\">Click here to shop more!<a>";

            await _emailSender.SendEmailAsync(user.Email, subject, message);

            return Redirect("/Checkout/Receipt");
        }

        public class CheckoutInput
        {
            [Display(Name = "Purchased Date:")]
            public DateTime Date { get; set; }

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

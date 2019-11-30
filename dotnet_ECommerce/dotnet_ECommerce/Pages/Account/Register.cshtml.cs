using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using dotnet_ECommerce.Data;
using dotnet_ECommerce.Models;
using dotnet_ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace dotnet_ECommerce.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IShop _shop;

        public IConfiguration Configuration { get; }

        /// <summary>
        /// A property to be available on the Model property in the Razor Page
        /// It uses BindProperty attribute to access the values outside of the handler method
        /// </summary>
        [BindProperty]
        public RegisterInput Input { get; set; }

        /// <summary>
        /// A property that brings in SignInManager depdency to be used in the class
        /// </summary>
        /// <param name="userManager">UserManager context</param>
        /// <param name="signInManager">SignInManager context</param>
        public RegisterModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, IShop shop)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            Configuration = configuration;
            _shop = shop;
        }



        /// <summary>
        /// A handler method to process the default GET request
        /// </summary>
        public void OnGet()
        {

        }

        /// <summary>
        /// A handler method to process a POST request after a user's registration information has been entered
        /// </summary>
        /// <returns>Home page upon successful registration</returns>
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = Input.Email,
                    Email = Input.Email
                };

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    Claim name = new Claim("FullName", $"{Input.FirstName} {Input.LastName}");
                    Claim email = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    List<Claim> claims = new List<Claim> { name, email };
                    await _userManager.AddClaimsAsync(user, claims);
                    await _signInManager.SignInAsync(user, false);

                    if (Input.Email == Configuration["AdminRoles"])
                    {
                        await _userManager.AddToRoleAsync(user, ApplicationRoles.Admin);
                    }

                    await _userManager.AddToRoleAsync(user, ApplicationRoles.Member);

                    var cart = new Cart
                    {
                        UserID = user.Id
                    };

                    await _shop.CreateCartAsync(cart);
                    
                    Response.Redirect("/");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return Page();
        }

        /// <summary>
        /// A class to define the RegisterInput
        /// </summary>
        public class RegisterInput
        {
            [Required]
            [Display(Name = "First Name:")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name:")]
            public string LastName { get; set; }

            [Required]
            [EmailAddress]
            [DataType(DataType.EmailAddress)]
            [Display(Name = "Email Address:")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long", MinimumLength = 6)]
            [Display(Name = "Password:")]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
            [Display(Name = "Confirm Password:")]
            public string ConfirmPassword { get; set; }

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

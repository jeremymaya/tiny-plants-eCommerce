using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ECommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet_ECommerce.Pages.Account
{
    public class LoginModel : PageModel
    {
        private SignInManager<ApplicationUser> _signInManager;

        /// <summary>
        /// A property to be available on the Model property in the Razor Page
        /// It uses BindProperty attribute to access the values outside of the handler method
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        /// A property that brings in SignInManager depdency to be used in the class
        /// </summary>
        /// <param name="signInManager"></param>
        public LoginModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        /// <summary>
        /// Handler method to process the default GET request
        /// </summary>
        public void OnGet()
        {

        }

        /// <summary>
        /// Handler method to process a POST request after a user's login information has been entered
        /// </summary>
        /// <returns>Home page upon successful login</returns>
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, false);
                if (result.Succeeded)
                {
                    Response.Redirect("/");
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Invalid Login Attempt");
                    return Page();
                }
            }
            return Page();
        }

        /// <summary>
        /// Class to define the InputModel
        /// </summary>
        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
            public bool RememberMe { get; set; }
        }
    }
}
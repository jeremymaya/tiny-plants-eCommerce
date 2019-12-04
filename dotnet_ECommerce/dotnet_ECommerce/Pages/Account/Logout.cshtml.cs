using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ECommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet_ECommerce.Pages.Account
{
    /// <summary>
    /// Bring in SignInManager dependency to help sign in a user
    /// If the user signs out, redirect the user to main page
    /// </summary>
    public class LogOutModel : PageModel
    {
        private SignInManager<ApplicationUser> _signInManager;

        public LogOutModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }

    }
}

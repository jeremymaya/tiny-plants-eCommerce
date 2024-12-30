using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TinyPlants.Models;

namespace TinyPlants.Pages.Account
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

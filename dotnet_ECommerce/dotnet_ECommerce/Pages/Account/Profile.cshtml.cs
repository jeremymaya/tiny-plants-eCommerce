using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ECommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace dotnet_ECommerce.Pages.Account
{
    public class ProfileModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public ApplicationUser CurrentUser { get; set; }

        /// <summary>
        /// A handler method to process the default GET request for Account/Profile to display currently logged in user data from the connencted database
        /// </summary>
        /// <returns>Profile.cshtml with the user data from the connected database</returns>
        public async Task OnGetAsync()
        {
            CurrentUser = await _userManager.GetUserAsync(User);
        }

        /// <summary>
        /// A handler method to process a POST request for Account/Profile to modify currently looged in user's data by saving an updated User object into the connected database
        /// </summary>
        /// <returns>Profile.cshtml with updated user data</returns>
        public async Task<RedirectToPageResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.GetUserAsync(User);

                user.FirstName = Request.Form["FirstName"];
                user.LastName = Request.Form["LastName"];
                user.Address = Request.Form["Address"];
                user.Address2 = Request.Form["Address2"];
                user.City = Request.Form["City"];
                user.State = Request.Form["State"];
                user.Zip = Request.Form["Zip"];

                try
                {
                    await _userManager.UpdateAsync(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            return RedirectToPage();
        }

        /// <summary>
        /// Probably wont need this since we are grabbing infomration from the form directly - BindProperty is not being used
        /// </summary>
        public class ProfileInput
        {
            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            public string Address { get; set; }

            [Display(Name = "Address 2")]
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

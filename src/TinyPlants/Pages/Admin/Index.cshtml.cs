using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TinyPlants.Pages.Admin
{
    /// <summary>
    /// Add Authorize tag and add policy so only the admin roles can access this page
    /// </summary>
    [Authorize(Policy="AdminOnly")]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}

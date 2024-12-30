using Microsoft.AspNetCore.Mvc.RazorPages;
using TinyPlants.Models;
using TinyPlants.Models.Interfaces;

namespace TinyPlants.Pages;

public class IndexModel : PageModel
{
    /// <summary>
    /// Dependency injection to establish a private connection to a database table by injecting an interface
    /// </summary>
    private readonly IInventoryManager _inventoryManager;

    /// <summary>
    /// A contructor to set propety to the corresponding interface instance
    /// </summary>
    /// <param name="context">IInventory interface</param>
    public IndexModel(IInventoryManager inventoryManager)
    {
        _inventoryManager = inventoryManager;
    }

    /// <summary>
    /// A property to be available on the Model property in the Razor Page
    /// </summary>
    public IList<Product> FeaturedProducts { get; set; }

    /// <summary>
    /// Asynchronous handler method to process the default GET request
    /// </summary>
    /// <returns>List of all products marked as IsFeatured from the database</returns>
    public async Task OnGetAsync()
    {
        FeaturedProducts = await _inventoryManager.GetFeaturedInventoriesAsync();
    }
}

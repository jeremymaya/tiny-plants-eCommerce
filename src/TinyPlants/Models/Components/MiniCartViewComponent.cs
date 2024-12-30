using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TinyPlants.Models.Interfaces;

namespace TinyPlants.Models.Components;

public class MiniCartViewComponent : ViewComponent
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IShopManager _shopManager;

    public MiniCartViewComponent(UserManager<ApplicationUser> userManager, IShopManager shopManager)
    {
        _userManager = userManager;
        _shopManager = shopManager;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var userId = _userManager.GetUserId((System.Security.Claims.ClaimsPrincipal)User);
        var cartItems = await _shopManager.GetCartItemsByUserIdAsync(userId);

        return View(cartItems);
    }
}

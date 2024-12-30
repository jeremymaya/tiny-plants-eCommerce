using Microsoft.AspNetCore.Identity;
using TinyPlants.Data;

namespace TinyPlants.Models;

public static class RoleInitializer
{
    
    private static readonly List<IdentityRole> Roles =
    [
        new IdentityRole
        {
            Name = ApplicationRoles.Admin,
            NormalizedName = ApplicationRoles.Admin.ToUpper(),
            ConcurrencyStamp = Guid.NewGuid().ToString()
        },
        new IdentityRole
        {
            Name = ApplicationRoles.Member,
            NormalizedName = ApplicationRoles.Member.ToUpper(),
            ConcurrencyStamp = Guid.NewGuid().ToString()
        }
    ];

    /// <summary>
    /// Initializes the roles in the application.
    /// </summary>
    /// <param name="serviceProvider">The service provider.</param>
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var logger = serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger("RoleInitializer");

        try
        {
            foreach (var role in Roles)
            {
                if (role.Name != null && !await roleManager.RoleExistsAsync(role.Name))
                {
                    await roleManager.CreateAsync(role);
                    logger.LogInformation($"Role {role.Name} created successfully.");
                }
            }

            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            await SeedDataAsync(context, logger);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while initializing roles.");
        }
    }

    /// <summary>
    /// Seeds the initial data in the application.
    /// </summary>
    /// <param name="context">The application database context.</param>
    /// <param name="logger">The logger instance.</param>
    public static async Task SeedDataAsync(ApplicationDbContext context, ILogger logger)
    {
        try
        {
            if (!context.Users.Any())
            {
                foreach (var role in Roles)
                {
                    context.Roles.Add(role);
                }
                logger.LogInformation("Seeding initial data.");
                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while seeding data.");
        }
    }
}

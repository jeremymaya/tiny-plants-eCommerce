using dotnet_ECommerce.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_ECommerce.Models
{
    public class RoleInitializer
    {
        /// <summary>
        /// Create a List to store all the Roles of IdentityRole type
        /// </summary>
        private static readonly List<IdentityRole> Roles = new List<IdentityRole>()
        {
            new IdentityRole { Name = ApplicationRoles.Admin, NormalizedName = ApplicationRoles.Admin.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },
            new IdentityRole { Name = ApplicationRoles.Member, NormalizedName = ApplicationRoles.Member.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString()}
        };

        /// <summary>
        /// Seed the Roles data into ApplicationDbContext
        /// Calls AddRoles() method to add roles data
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void SeedData(IServiceProvider serviceProvider)
        {
            using (var dbContext = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                dbContext.Database.EnsureCreated();
                AddRoles(dbContext);
            }
        }

        /// <summary>
        /// If roles are already exist in ApplicationDbContext, return.
        /// Otherwise, loop throught Roles which is a List of roles and add each role into ApplicationDbContext and save the changes.
        /// </summary>
        /// <param name="dbContext"></param>
        private static void AddRoles(ApplicationDbContext dbContext)
        {
            if (dbContext.Roles.Any()) return;

            foreach (var role in Roles)
            {
                dbContext.Roles.Add(role);
                dbContext.SaveChanges();
            }
        }
    }
}

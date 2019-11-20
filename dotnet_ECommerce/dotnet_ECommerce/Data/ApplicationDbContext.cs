using System;
using dotnet_ECommerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace dotnet_ECommerce.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
        }
    }
}

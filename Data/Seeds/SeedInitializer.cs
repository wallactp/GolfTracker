using System.Linq;
using System.Threading.Tasks;
using GolfTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GolfTracker.Data.Seeds
{
    public static class SeedInitializer
    {
        public static async Task Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            await context.Database.MigrateAsync();
            await SeedDatabase(context, userManager, roleManager);
        }

        private static async Task SeedDatabase(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (!context.Addresses.Any())
            {
                var addressesSeed = new AddressesSeed(context);
                await addressesSeed.Seed();
            }

            if (!context.Users.Any())
            {
                var usersSeed = new UsersSeed(context, userManager, roleManager);
                await usersSeed.Seed();
            }
        }
    }    
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolfTracker.Models;
using Microsoft.AspNetCore.Identity;

namespace GolfTracker.Data.Seeds
{
    public class UsersSeed
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersSeed(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            // Add roles
            var roles = new[]
            {
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" }
            };

            // Create dummy user
            var dummyUser = new ApplicationUser
            {
                AccessFailedCount = 0,
                AddressId = _context.Addresses.FirstOrDefault().AddressId,
                Avatar = "wallactp",
                BirthDate = DateTime.Parse("04/06/1991"),
                ConcurrencyStamp = "d16ab7af-83df-4ce6-8642-bbb246e56878",
                Created = DateTime.Now,
                Email = "wallactp@gmail.com",
                EmailConfirmed = true,
                FirstName = "Tyler",
                LastName = "Wallace",
                LockoutEnabled = true,
                NormalizedEmail = "WALLACTP@GMAIL.COM",
                NormalizedUserName = "WALLACTP@GMAIL.COM",
                PasswordHash = "AQAAAAEAACcQAAAAEPQQV12GsXY9lu0QLFNXCrQFvgRCOojIsHuwUasHrjCidkVy3D8uJr7317p5+LbZjQ==", // Password = 123456
                PhoneNumberConfirmed = false,
                PhoneNumber = "1-757-784-5259",
                SecurityStamp = "61528385-724c-443b-87e6-4732235525fd",
                TwoFactorEnabled = false,
                UserName = "wallactp@gmail.com"
            };

            await SeedRoles(roles);
            var addedUser = await SeedUsers(dummyUser);
            await SeedUserRoles(addedUser, roles);
        }

        private async Task SeedRoles(IEnumerable<IdentityRole> roles)
        {
            foreach (var role in roles)
            {
                if (!_roleManager.Roles.Any(x => x.Id == role.Id))
                {
                    await _roleManager.CreateAsync(role);
                }
            }
        }

        private async Task<ApplicationUser> SeedUsers(ApplicationUser user)
        {
            await _userManager.CreateAsync(user);

            var createdUser = await _userManager.FindByEmailAsync(user.Email);
            return createdUser;
            
        }

        private async Task SeedUserRoles(ApplicationUser user, IEnumerable<IdentityRole> roles)
        {
            // Add dummy user to all roles
            await _userManager.AddToRolesAsync(user, roles.Select(x => x.Name));
        }
    }
}
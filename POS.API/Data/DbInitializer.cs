using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.API.Data
{
    public class DbInitializer
    {
        public static async Task SeedAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
           
            var roles = new[] { "Admin", "Manager", "Cashier" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            

            // Admin User
            var adminUser = new IdentityUser
            {
                UserName = "admin@pos.com",
                Email = "admin@pos.com",
                EmailConfirmed = true
            };

            if (userManager.Users.All(u => u.UserName != adminUser.UserName))
            {
                await userManager.CreateAsync(adminUser, "Admin@123");
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            // Manager User
            var managerUser = new IdentityUser
            {
                UserName = "manager@pos.com",
                Email = "manager@pos.com",
                EmailConfirmed = true
            };

            if (userManager.Users.All(u => u.UserName != managerUser.UserName))
            {
                await userManager.CreateAsync(managerUser, "Manager@123");
                await userManager.AddToRoleAsync(managerUser, "Manager");
            }

            // Cashier User
            var cashierUser = new IdentityUser
            {
                UserName = "cashier@pos.com",
                Email = "cashier@pos.com",
                EmailConfirmed = true
            };

            if (userManager.Users.All(u => u.UserName != cashierUser.UserName))
            {
                await userManager.CreateAsync(cashierUser, "Cashier@123");
                await userManager.AddToRoleAsync(cashierUser, "Cashier");
            }
        }
    }
}


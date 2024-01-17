using Microsoft.AspNetCore.Identity;

namespace BotanicalDB.Models
{
    /*
     * Brett Fowler
     * Course CPT-231-424 - C# Programming II
     * Module 12 Assignnent
     * 2023 Fall
     */

    public class SetupAdmin
    {
        // Create admin role
        public static async Task CreateAdminAsync(IServiceProvider serviceProvider)
        {
            RoleManager<IdentityRole> roleManager = serviceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();
            UserManager<IdentityUser> userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            // Assign default admin user credentials
            string userName = "admin";
            string password = "admin123";
            string role = "Admin";

            if (await roleManager.FindByNameAsync(role) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
            if (await userManager.FindByNameAsync(userName) == null)
            {
                IdentityUser user = new IdentityUser { UserName = userName };
                IdentityResult result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}

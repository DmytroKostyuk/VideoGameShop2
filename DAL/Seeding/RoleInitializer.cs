using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DAL.Seeding
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<MyRole> roleManager)
        {
            string adminUserName = "admin";
            string adminPassword = "Admin_1337";
            string adminEmail = "someAdmin@gmail.com";

            if (await roleManager.FindByNameAsync("admin") == null)
            { await roleManager.CreateAsync(new MyRole { Name = "admin" }); }

            if (await roleManager.FindByNameAsync("user") == null)
            { await roleManager.CreateAsync(new MyRole { Name = "user" }); }

            if(await roleManager.FindByNameAsync(adminUserName) == null)
            {
                User admin = new User { UserName = adminUserName, Email = adminEmail };

                IdentityResult result = await userManager.CreateAsync(admin, adminPassword);

                if(result.Succeeded)
                { await userManager.AddToRoleAsync(admin, "admin"); }
            }
        }
    }
}

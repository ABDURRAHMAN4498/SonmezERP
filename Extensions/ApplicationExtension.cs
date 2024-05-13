using Microsoft.AspNetCore.Identity;
using SonmezERP.Models;

namespace SonmezERP.Extensions
{
    public static class ApplicationExtension
    {
        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            const string adminUser = "Admin";
            const string adminPassword = "Admin+123456";



            //UserManager
            UserManager<AppUser> userManager = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<UserManager<AppUser>>();

            //RoleManager

            RoleManager<AppRole> roleManager = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<RoleManager<AppRole>>();
            AppUser user = await userManager.FindByNameAsync(adminUser);
            if (user is null)
            {
                user = new AppUser()
                {
                    UserName = adminUser
                };
                var result = await userManager.CreateAsync(user, adminPassword);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"hata : {error.Description}");
                    }
                    throw new Exception("Admin user could not created.");
                }

                var roleResult = await userManager.AddToRolesAsync(user,
                    roleManager
                        .Roles
                        .Select(r => r.Name)
                        .ToList());
                if (!roleResult.Succeeded)
                {
                    throw new Exception("System have problems with role defination for admin.");
                }
            }
        }
    }
}

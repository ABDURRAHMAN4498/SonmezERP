using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SonmezERP.Data;
using SonmezERP.Models;

namespace SonmezERP.Extensions
{
    public static class ApplicationExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SonmezERPContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("SonmezERP"));
                options.EnableSensitiveDataLogging(true);
            });
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(options=>
            {
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                
            })
            .AddEntityFrameworkStores<SonmezERPContext>();
        }

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
            AppUser? user = await userManager.FindByNameAsync(adminUser);
            if (user is null)
            {
                user = new AppUser()
                {
                    UserName = adminUser
                };
                var result = await userManager.CreateAsync(user, adminPassword);

                if (!result.Succeeded)
                {
                    
                    throw new Exception("Admin kullanıcı oluşturulamadı");
                }

                //List<string?> roles = roleManager.Roles.Select(x => x.Name).ToList();
                IdentityResult roleResult = await userManager.AddToRolesAsync(user,
                    new List<string>()
                    {
                        "Editor",
                        "Admin",
                        "User"
                    });
                if (!roleResult.Succeeded)
                {
                    throw new Exception("System have problems with role defination for admin.");
                }
            }
        }
    }
}

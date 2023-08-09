using LakeXplorerProject.Data.Static;
using LakeXplorerProject.Models;
using Microsoft.AspNetCore.Identity;

namespace LakeXplorerProject.Data
{
    public class AppDbInitializer
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Clients
                if (!context.Lakes.Any())
                {
                    context.Lakes.AddRange(new List<Lake>()
                    {
                        new Lake()
                        {
                            
                        },
                        new Lake()
                        {
                             
                        }

                    });
                    context.SaveChanges();
                }
              

            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles Section
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //User section
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var adminUser = await userManager.FindByEmailAsync("admin@gmail.com");
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Application Admin",
                        UserName = "app-admin",
                        Email = "admin@gmail.com",
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Labinot1234@.");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);

                }
                var appUser = await userManager.FindByEmailAsync("user@gmail.com");
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = "user@gmail.com",
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Labinot1234@.");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }



    }
}

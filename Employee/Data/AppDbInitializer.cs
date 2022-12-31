using Employee.Data.Static;
using Employee.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<StaffContext>();
                context.Database.EnsureCreated();
                //Staff
                if (!context.Staffs.Any())
                {
                    context.Staffs.AddRange(new List<Staff>()
                    {
                        new Staff()
                        {
                            FullName = "Hari",
                            Position = "Manager",
                            Phone = "100",
                            Address = "Kavre"

                        },
                         new Staff()
                        {
                            FullName = "Ram",
                            Position = "Manager",
                            Phone = "101",
                            Address = "Kavre"
                        },
                          new Staff()
                        {
                            FullName = "Shyam",
                            Position = "Manager",
                            Phone = "102",
                            Address = "Kavre"

                        },
                           new Staff()
                        {
                            FullName = "Gopal",
                            Position = "Manager",
                            Phone = "103",
                            Address = "Kavre"
                        },
                            new Staff()
                        {
                            FullName = "Manoj",
                            Position = "Manager",
                            Phone = "105",
                            Address = "Kavre"
                        },
                    });
                    context.SaveChanges();
                }
            }
        
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }

 
            }

        }
    }
}

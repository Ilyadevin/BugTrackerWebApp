using BugTrackerWebApp.Data.Enum;
using BugTrackerWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace BugTrackerWebApp.Data;


public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {
            //// Look for any users.
            //if (context.AppUsers.Any())
            //{
            //    return; // DB has been seeded
            //}

            //context.AppUsers.AddRange(
            //    new AppUser
            //    {
            //        Name = "John Doe",
            //        Email = "john.doe@example.com",
            //        Password = "password123",
            //        Role = "Developer",
            //        Avatar = "/img/developerImage.jpg"
            //    },
            //    new AppUser
            //    {
            //        Name = "Jane Smith",
            //        Email = "jane.smith@example.com",
            //        Password = "password456",
            //        Role = "Manager",
            //        Avatar = "/img/adminImage"
            //    }
            //);

            context.Projects.AddRange(
                new Project
                {
                    Name = "Project A",
                    Description = "Description for Project A",
                    ManagerUserId = 1,
                    StartDate = DateTime.Now,
                    Status = ProjectStatus.InProgress
                },
                new Project
                {
                    Name = "Project B",
                    Description = "Description for Project B",
                    ManagerUserId = 2,
                    StartDate = DateTime.Now,
                    Status = ProjectStatus.NotStarted
                }
            );

            context.Tasks.AddRange(
                new Task_
                {
                    Title = "Task 1",
                    Description = "Description for Task 1",
                    AssignedToUserId = 1,
                    CreatedDate = DateTime.Now,
                    Status = TaskStatus.RanToCompletion,
                    Priority = TaskPriority.High
                },
                new Task_
                {
                    Title = "Task 2",
                    Description = "Description for Task 2",
                    AssignedToUserId = 2,
                    CreatedDate = DateTime.Now,
                    Status = TaskStatus.Created,
                    Priority = TaskPriority.Low
                }
            );

            context.Bugs.AddRange(
                new Bug
                {
                    Title = "Bug 1",
                    Description = "Description for Bug 1",
                    ProjectId = 1,
                    AssignedToUserId = 1,
                    CreatedDate = DateTime.Now,
                    Status = BugStatus.Open,
                    Criticality = BugPriority.High,
                    ScreenShotOfError = "/img/errorMessageSample2.png"
                },
                new Bug
                {
                    Title = "Bug 2",
                    Description = "Description for Bug 2",
                    ProjectId = 2,
                    AssignedToUserId = 2,
                    CreatedDate = DateTime.Now,
                    Status = BugStatus.Closed,
                    Criticality = BugPriority.Low,
                    ScreenShotOfError = "/img/errorMessageSample4.png"

                }
            );

            context.SaveChanges();
        }
    }
    public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
    {
        using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
        //Roles
        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        if (!await roleManager.RoleExistsAsync(UserRoles.User))
            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        //Users
        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        string adminUserEmail = "johndoe@example.com";

        var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
        if (adminUser == null)
        {
            var newAdminUser = new AppUser()
            {
                UserName = "JohnDoe",
                Email = adminUserEmail,
                EmailConfirmed = true,
            };
            await userManager.CreateAsync(newAdminUser, "Coding@1234?");
            await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
        }

        string appUserEmail = "janesmith@example.com";

        var appUser = await userManager.FindByEmailAsync(appUserEmail);
        if (appUser == null)
        {
            var newAppUser = new AppUser()
            {
                UserName = "JaneSmith",
                Email = appUserEmail,
                EmailConfirmed = true,
            };
            await userManager.CreateAsync(newAppUser, "Coding@1234?");
            await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
        }
    }
}

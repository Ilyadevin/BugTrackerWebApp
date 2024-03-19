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
            if (!context.AppUsers.Any())
            {
                var user1 = new AppUser
                {
                    UserName = "JohnDoe",
                    Email = "john.doe@example.com",
                    EmailConfirmed = true,
                    ProfileImageUrl = "/img/developerImage.jpg"
                };
                var user2 = new AppUser
                {
                    UserName = "JaneSmith",
                    Email = "jane.smith@example.com",
                    EmailConfirmed = true,
                    ProfileImageUrl = "/img/adminImage.jpg"
                };
                var userManager = serviceProvider.GetService<UserManager<AppUser>>();
                var passwordHasher = serviceProvider.GetService<IPasswordHasher<AppUser>>();

                user1.PasswordHash = passwordHasher.HashPassword(user1, "Password123!");
                user2.PasswordHash = passwordHasher.HashPassword(user2, "Password456!");

                context.AppUsers.AddRange(user1, user2);
                context.SaveChanges();
            }

            if (!context.Projects.Any())
            {
                var project1 = new Project
                {
                    Name = "Project A",
                    Description = "Description for Project A",
                    ManagerUserId = 1,
                    StartDate = DateTime.Now,
                    Status = ProjectStatus.InProgress
                };
                var project2 = new Project
                {
                    Name = "Project B",
                    Description = "Description for Project B",
                    ManagerUserId = 2,
                    StartDate = DateTime.Now,
                    Status = ProjectStatus.NotStarted
                };

                context.Projects.AddRange(project1, project2);
                context.SaveChanges();
            }

            if (!context.Bugs.Any())
            {
                var bug1 = new Bug
                {
                    Title = "Bug 1",
                    Description = "Description for Bug 1",
                    ProjectId = 1,
                    AssignedToUserId = 1,
                    CreatedDate = DateTime.Now,
                    Status = BugStatus.Open,
                    Criticality = BugPriority.High,
                    ScreenShotOfError = "/img/errorMessageSample2.png"
                };
                var bug2 = new Bug
                {
                    Title = "Bug 2",
                    Description = "Description for Bug 2",
                    ProjectId = 2,
                    AssignedToUserId = 2,
                    CreatedDate = DateTime.Now,
                    Status = BugStatus.Closed,
                    Criticality = BugPriority.Low,
                    ScreenShotOfError = "/img/errorMessageSample4.png"
                };

                context.Bugs.AddRange(bug1, bug2);
                context.SaveChanges();
            }

            if (!context.Tasks.Any())
            {
                var task1 = new Task_
                {
                    Title = "Task 1",
                    Description = "Description for Task 1",
                    AssignedToUserId = 1,
                    CreatedDate = DateTime.Now,
                    Status = TaskStatus.RanToCompletion,
                    Priority = TaskPriority.High
                };
                var task2 = new Task_
                {
                    Title = "Task 2",
                    Description = "Description for Task 2",
                    AssignedToUserId = 2,
                    CreatedDate = DateTime.Now,
                    Status = TaskStatus.Created,
                    Priority = TaskPriority.Low
                };

                context.Tasks.AddRange(task1, task2);
                context.SaveChanges();
            }
        }
    }
}

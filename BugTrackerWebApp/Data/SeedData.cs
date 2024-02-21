using BugTrackerWebApp.Data.Enum;
using BugTrackerWebApp.Models;
using Microsoft.EntityFrameworkCore;
namespace BugTrackerWebApp.Data;


public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {
            // Look for any users.
            if (context.AppUsers.Any())
            {
                return; // DB has been seeded
            }

            context.AppUsers.AddRange(
                new AppUser
                {
                    Name = "John Doe",
                    Email = "john.doe@example.com",
                    Password = "password123",
                    Role = "Developer"
                },
                new AppUser
                {
                    Name = "Jane Smith",
                    Email = "jane.smith@example.com",
                    Password = "password456",
                    Role = "Manager"
                }
            );

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
                    Criticality = BugPriority.High
                },
                new Bug
                {
                    Title = "Bug 2",
                    Description = "Description for Bug 2",
                    ProjectId = 2,
                    AssignedToUserId = 2,
                    CreatedDate = DateTime.Now,
                    Status = BugStatus.Closed,
                    Criticality = BugPriority.Low
                }
            );

            context.SaveChanges();
        }
    }
}

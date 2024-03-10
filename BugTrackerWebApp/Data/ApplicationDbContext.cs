using BugTrackerWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BugTrackerWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    //public class ApplicationDbContext : IdentityDbContext<AppUser, add after this roles>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Task_> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}

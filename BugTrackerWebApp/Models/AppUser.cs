
namespace BugTrackerWebApp.Models
{
    public class AppUser : Microsoft.AspNetCore.Identity.IdentityUser
    {
        //public string? Name { get; set; }
        //public string? Password { get; set; }
        //public string? Role { get; set; }
        //public string? Avatar { get; set; }
        public ICollection<Bug> Bugs { get; set; }
        public ICollection<Task_> Tasks { get; set; }

    }
}

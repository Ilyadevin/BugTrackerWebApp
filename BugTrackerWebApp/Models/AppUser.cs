
namespace BugTrackerWebApp.Models
{
    public class AppUser : Microsoft.AspNetCore.Identity.IdentityUser
    {
        public ICollection<Bug> Bugs { get; set; }
        public ICollection<Task_> Tasks { get; set; }
        public string? ProfileImageUrl { get; set; }

    }
}

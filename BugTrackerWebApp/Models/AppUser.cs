using Microsoft.AspNetCore.Identity;

namespace BugTrackerWebApp.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        //public ICollection<Bug> Bugs { get; set; }
        //public ICollection<Task_> Tasks{ get; set; }

    }
}

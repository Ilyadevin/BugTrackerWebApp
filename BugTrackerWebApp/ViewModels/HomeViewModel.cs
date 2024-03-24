using BugTrackerWebApp.Models;

namespace BugTrackerWebApp.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Bug>? Bugs { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public HomeUserCreateViewModel Register { get; set; } = new HomeUserCreateViewModel();
    }
}
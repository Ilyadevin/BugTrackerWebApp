using BugTrackerWebApp.Models;

namespace BugTrackerWebApp.ViewModels
{
    public class DashboardViewModel
    {
        public List<Bug> Bugs { get; set; }
        public List<Project> Projects { get; set; }
        public List<Task_> Tasks { get; set; }
    }

}

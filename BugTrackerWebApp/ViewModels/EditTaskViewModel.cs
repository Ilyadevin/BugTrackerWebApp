using BugTrackerWebApp.Data.Enum;

namespace BugTrackerWebApp.ViewModels
{
    public class EditTaskViewModel
    {
        public string? URL { get; set; }
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? AssignedToUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public TaskStatus? Status { get; set; }
        public TaskPriority? Priority { get; set; }
        public string? GitHubAction { get; set; }
    }
}

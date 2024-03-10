using BugTrackerWebApp.Data.Enum;

namespace BugTrackerWebApp.Models
{
    public class Task_
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? AssignedToUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public TaskStatus? Status { get; set; }
        public TaskPriority? Priority { get; set; }
        public string? GitHubAction { get; set; }
        public string? AppUserId { get; set; }

    }
}

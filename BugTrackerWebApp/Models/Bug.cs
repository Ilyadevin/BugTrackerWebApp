using BugTrackerWebApp.Data.Enum;

namespace BugTrackerWebApp.Models
{
    public class Bug
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? ProjectId { get; set; }
        public int? AssignedToUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ResolvedDate { get; set; }
        public BugStatus? Status { get; set; }
        public BugPriority? Criticality { get; set; }
        public string? ScreenShotOfError { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}

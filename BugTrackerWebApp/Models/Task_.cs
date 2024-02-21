using BugTrackerWebApp.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    }
}

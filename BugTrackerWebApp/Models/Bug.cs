using BugTrackerWebApp.Data.Enum;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    }
}

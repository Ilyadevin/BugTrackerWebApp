﻿using BugTrackerWebApp.Data.Enum;

namespace BugTrackerWebApp.ViewModels
{
    public class EditProjectViewModel
    {
        public string? URL { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? ManagerUserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ProjectStatus? Status { get; set; }
        public string? ProjectLink { get; set; }
        public string AppUserId { get; set; }
    }
}

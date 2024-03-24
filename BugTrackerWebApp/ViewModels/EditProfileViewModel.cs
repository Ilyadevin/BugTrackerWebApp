namespace BugTrackerWebApp.ViewModels
{
    public class EditProfileViewModel
    {
        //public string id { get; set; }
        public string UserName { get; set; }
        public string? ProfileImageUrl { get; set; }
        public IFormFile? Image { get; set; }
    }
}
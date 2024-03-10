using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BugTrackerWebApp.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name="Emaol addres")]
        [Required(ErrorMessage ="Email is required")]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

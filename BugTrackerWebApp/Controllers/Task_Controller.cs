using Microsoft.AspNetCore.Mvc;

namespace BugTrackerWebApp.Controllers
{
    public class Task_Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

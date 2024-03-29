using BugTrackerWebApp.Interfaces;
using BugTrackerWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackerWebApp.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRespository;
        private readonly IPhotoService _photoService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardController(IDashboardRepository dashboardRespository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {
            _dashboardRespository = dashboardRespository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userTasks = await _dashboardRespository.GetAllUserTasks();
                var userBugs = await _dashboardRespository.GetAllUserBugs();
                var userProjects = await _dashboardRespository.GetAllUserProjects();
                var dashboardViewModel = new DashboardViewModel()
                {
                    Tasks = userTasks,
                    Bugs = userBugs,
                    Projects = userProjects,
                };
                return View(dashboardViewModel);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
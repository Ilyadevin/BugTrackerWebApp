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

        public DashboardController(IDashboardRepository dashboardRespository, IPhotoService photoService)
        {
            _dashboardRespository = dashboardRespository;
            _photoService = photoService;
        }

        public async Task<IActionResult> Index()
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
    }
}
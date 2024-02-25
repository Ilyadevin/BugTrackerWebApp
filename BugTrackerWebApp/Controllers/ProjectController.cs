using BugTrackerWebApp.Data;
using BugTrackerWebApp.Interfaces;
using BugTrackerWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackerWebApp.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Project> projects = await _projectRepository.GetAll();
            return View(projects);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Project project = await _projectRepository.GetByIdAsync(id);
            return View(project);
        }
    }
}

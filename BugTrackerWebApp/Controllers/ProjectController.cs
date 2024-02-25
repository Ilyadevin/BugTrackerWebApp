using BugTrackerWebApp.Data;
using BugTrackerWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackerWebApp.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var projects = _context.Projects.ToList();

            return View(projects);
        }

        public IActionResult Detail(int id)
        {
            Project project = _context.Projects.FirstOrDefault(bug => bug.Id == id);
            return View(project);
        }
    }
}

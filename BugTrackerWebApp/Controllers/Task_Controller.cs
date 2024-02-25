using BugTrackerWebApp.Data;
using BugTrackerWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackerWebApp.Controllers
{
    public class Task_Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Task_Controller(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var tasks = _context.Tasks.ToList();
            return View(tasks);
        }

        public IActionResult Detail(int id)
        {
            Task_ task = _context.Tasks.FirstOrDefault(bug => bug.Id == id);
            return View(task);
        }
    }
}

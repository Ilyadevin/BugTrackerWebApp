using BugTrackerWebApp.Data;
using BugTrackerWebApp.Interfaces;
using BugTrackerWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackerWebApp.Controllers
{
    public class Task_Controller : Controller
    {
        private readonly ITaskRepository _taskRepository;

        public Task_Controller(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Task_> tasks = await _taskRepository.GetAll();
            return View(tasks);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Task_ projects = await _taskRepository.GetByIdAsync(id);
            return View(projects);
        }
    }
}

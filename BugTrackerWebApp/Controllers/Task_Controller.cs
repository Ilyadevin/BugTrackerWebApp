using BugTrackerWebApp.Data;
using BugTrackerWebApp.Interfaces;
using BugTrackerWebApp.Models;
using BugTrackerWebApp.Repository;
using BugTrackerWebApp.ViewModels;
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
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskViewModel taskVM)
        {

            if (ModelState.IsValid)
            {
                var task = new Task_
                {
                    Title = taskVM.Title,
                    Description = taskVM.Description,
                    Status = taskVM.Status,
                    Priority = taskVM.Priority,
                };
                _taskRepository.Add(task);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Error in filling fileds");
            }
            return View(taskVM);
        }
    }
}

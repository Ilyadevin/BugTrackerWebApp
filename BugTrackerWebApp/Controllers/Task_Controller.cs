using BugTrackerWebApp.Interfaces;
using BugTrackerWebApp.Models;
using BugTrackerWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackerWebApp.Controllers
{
    public class Task_Controller : Controller
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public Task_Controller(ITaskRepository taskRepository, IHttpContextAccessor contextAccessor)
        {
            _taskRepository = taskRepository;
            _contextAccessor = contextAccessor;
        }
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                IEnumerable<Task_> tasks = await _taskRepository.GetAll();
                return View(tasks);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> Detail(int id)
        {
            Task_ projects = await _taskRepository.GetByIdAsync(id);
            return View(projects);
        }
        public async Task<IActionResult> Create()
        {
            var curUserId = _contextAccessor.HttpContext.User.GetUserId();
            var createTaskViewModel = new CreateTaskViewModel
            {
                AppUserId = curUserId
            };
            return View(createTaskViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskViewModel taskVM)
        {

            if (ModelState.IsValid)
            {
                var task = new Task_
                {
                    AppUserId = taskVM.AppUserId,
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

        public async Task<IActionResult> Edit(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            if (task == null) return View("Error");
            var taskVM = new EditTaskViewModel
            {
                AppUserId = task.AppUserId,
                Title = task.Title,
                Description = task.Description,
            };
            return View(taskVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditTaskViewModel taskVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit task");
                return View("Edit", taskVM);
            }
            var userTask = await _taskRepository.GetByIdAsyncNoTracking(id);
            if (userTask != null)
            {
                var task = new Task_
                {
                    AppUserId = userTask.AppUserId,
                    Id = id,
                    Title = taskVM.Title,
                    Description = taskVM.Description,
                };
                _taskRepository.Update(task);
                return RedirectToAction("Index");
            }
            else
            {
                return View(taskVM);
            }
        }
    }
}

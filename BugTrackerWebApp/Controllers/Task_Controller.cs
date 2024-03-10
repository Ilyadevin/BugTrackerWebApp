using BugTrackerWebApp.Interfaces;
using BugTrackerWebApp.Models;
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
                    //AssignedToUserId = taskVM.AssignedToUserId,
                    //CreatedDate = taskVM.CreatedDate,
                    //CompletedDate = taskVM.CompletedDate,
                    //GitHubAction = taskVM.GitHubAction
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
                Title = task.Title,
                Description = task.Description,
                //URL = task.ScreenShotOfError
                //ProjectId = taskVM.ProjectId,
                //AssignedToUserId = taskVM.AssignedToUserId,
                //CreatedDate = taskVM.CreatedDate,
                //ResolvedDate = taskVM.ResolvedDate,
                //Status = taskVM.Status,
                //Criticality = taskVM.Criticality,
                //AppUser = taskVM.AppUser
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
                    Id = id,
                    Title = taskVM.Title,
                    Description = taskVM.Description,
                    //URL = taskVM.ScreenShotOfError
                    //ProjectId = taskVM.ProjectId,
                    //AssignedToUserId = taskVM.AssignedToUserId,
                    //CreatedDate = taskVM.CreatedDate,
                    //ResolvedDate = taskVM.ResolvedDate,
                    //Status = taskVM.Status,
                    //Criticality = taskVM.Criticality,
                    //AppUser = taskVM.AppUser
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

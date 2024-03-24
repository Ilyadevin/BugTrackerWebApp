using BugTrackerWebApp.Interfaces;
using BugTrackerWebApp.Models;
using BugTrackerWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackerWebApp.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public ProjectController(IProjectRepository projectRepository, IHttpContextAccessor contextAccessor)
        {
            _projectRepository = projectRepository;
            _contextAccessor = contextAccessor;
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
        public async Task<IActionResult> Create()
        {
            var curUserId = _contextAccessor.HttpContext?.User.GetUserId();
            var createProjectViewModel = new CreateProjectViewModel
            {
                AppUserId = curUserId
            };
            return View(createProjectViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectViewModel projectVM)
        {
            if (ModelState.IsValid)
            {
                var project = new Project
                {
                    AppUserId = projectVM.AppUserId,
                    Name = projectVM.Name,
                    Description = projectVM.Description,
                    Status = projectVM.Status,
                    ProjectLink = projectVM.ProjectLink
                };
                _projectRepository.Add(project);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "There is an error in filling fields of the form");
            }
            return View(projectVM);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null) return View("Error");
            var projectVM = new EditProjectViewModel
            {
                AppUserId = project.AppUserId,
                Name = project.Name,
                Description = project.Description,
            };
            return View(projectVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditProjectViewModel projectVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit project");
                return View("Edit", projectVM);
            }
            var userTask = await _projectRepository.GetByIdAsyncNoTracking(id);
            if (userTask != null)
            {
                var project = new Project
                {
                    AppUserId = userTask.AppUserId,
                    Id = id,
                    Name = projectVM.Name,
                    Description = projectVM.Description,
                };
                _projectRepository.Update(project);
                return RedirectToAction("Index");
            }
            else
            {
                return View(projectVM);
            }
        }
    }
}

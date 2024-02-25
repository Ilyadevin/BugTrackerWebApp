using BugTrackerWebApp.Data;
using BugTrackerWebApp.Interfaces;
using BugTrackerWebApp.Models;
using BugTrackerWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackerWebApp.Controllers
{
    public class BugController : Controller
    {
        private readonly IBugRepository _bugRepository;
        private readonly IPhotoService _photoService;

        public BugController(IBugRepository bugRepository, IPhotoService photoService)
        {
            _bugRepository = bugRepository;
            _photoService = photoService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Bug> bugs = await _bugRepository.GetAll();
            return View(bugs);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Bug bug = await _bugRepository.GetByIdAsync(id);
            return View(bug);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBugViewModel bugVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(bugVM.ScreenShotOfError);

                var bug = new Bug
                {
                    Title = bugVM.Title,
                    Description = bugVM.Description,
                    ScreenShotOfError = result.Url.ToString(),

                };
                _bugRepository.Add(bug);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload Failed");
            }
            return View(bugVM);
        }
    }
}

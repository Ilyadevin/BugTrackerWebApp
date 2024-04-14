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
        private readonly IHttpContextAccessor _contextAccessor;

        public BugController(IBugRepository bugRepository, IPhotoService photoService, IHttpContextAccessor contextAccessor)
        {
            _bugRepository = bugRepository;
            _photoService = photoService;
            _contextAccessor = contextAccessor;
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
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var curUserId = _contextAccessor.HttpContext.User.GetUserId();
            var createBugViewModel = new CreateBugViewModel
            {
                AppUserId = curUserId
            };
            return View(createBugViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBugViewModel bugVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(bugVM.ScreenShotOfError);

                var bug = new Bug
                {
                    AppUserId = bugVM.AppUserId,
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
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var bug = await _bugRepository.GetByIdAsync(id);
            if (bug == null) return View("Error");
            var bugVM = new EditBugViewModel
            {
                AppUserId = bug.AppUserId,
                Title = bug.Title,
                Description = bug.Description,
                URL = bug.ScreenShotOfError
            };
            return View(bugVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditBugViewModel bugVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit bug");
                return View("Edit", bugVM);
            }
            var userBug = await _bugRepository.GetByIdAsyncNoTracking(id);
            if (userBug != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(userBug.ScreenShotOfError);
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(bugVM);
                }
                var screenShotResult = await _photoService.AddPhotoAsync(bugVM.ScreenShotOfError);
                var bug = new Bug
                {
                    AppUserId = userBug.AppUserId,
                    Id = id,
                    Title = bugVM.Title,
                    Description = bugVM.Description,
                    ScreenShotOfError = screenShotResult.Url.ToString(),
                };
                _bugRepository.Update(bug);
                return RedirectToAction("Index");
            }
            else
            {
                return View(bugVM);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var bugDetails = await _bugRepository.GetByIdAsync(id);
            if (bugDetails == null) return View("Error");
            return View(bugDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteBug(int id)
        {
            var clubDetails = await _bugRepository.GetByIdAsync(id);

            if (clubDetails == null)
            {
                return View("Error");
            }

            if (!string.IsNullOrEmpty(clubDetails.ScreenShotOfError))
            {
                _ = _photoService.DeletePhotoAsync(clubDetails.ScreenShotOfError);
            }

            _bugRepository.Delete(clubDetails);
            return RedirectToAction("Index");
        }
    }
}

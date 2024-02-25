using BugTrackerWebApp.Data;
using BugTrackerWebApp.Interfaces;
using BugTrackerWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackerWebApp.Controllers
{
    public class BugController : Controller
    {
        private readonly IBugRepository _bugRepository;

        public BugController(IBugRepository bugRepository)
        {
            _bugRepository = bugRepository;
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
    }
}

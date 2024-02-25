﻿using BugTrackerWebApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackerWebApp.Controllers
{
    public class BugController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BugController(ApplicationDbContext context) 
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var bugs = _context.Bugs.ToList();
            return View(bugs);
        }
    }
}

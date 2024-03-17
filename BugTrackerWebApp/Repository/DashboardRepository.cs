using BugTrackerWebApp.Data;
using BugTrackerWebApp.Interfaces;
using BugTrackerWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTrackerWebApp.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<AppUser> GetUserById(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetByIdNoTracking(string id)
        {
            return await _context.Users.Where(u => u.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public bool Update(AppUser user)
        {
            _context.Users.Update(user);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public async Task<List<Task_>> GetAllUserTasks()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userTasks = _context.Tasks.Where(r => r.AppUser.Id == curUser);
            return userTasks.ToList();
        }

        public async Task<List<Bug>> GetAllUserBugs()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userBugs = _context.Bugs.Where(r => r.AppUser.Id == curUser);
            return userBugs.ToList();
        }

        public async Task<List<Project>> GetAllUserProjects()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userProjects = _context.Projects.Where(r => r.AppUser.Id == curUser);
            return userProjects.ToList();
        }
    }
}

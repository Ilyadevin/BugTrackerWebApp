using BugTrackerWebApp.Models;
namespace BugTrackerWebApp.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Task_>> GetAllUserTasks();
        Task<List<Bug>> GetAllUserBugs();
        Task<List<Project>> GetAllUserProjects();
        Task<AppUser> GetUserById(string id);
        Task<AppUser> GetByIdNoTracking(string id);
        bool Update(AppUser user);
        bool Save();
    }
}
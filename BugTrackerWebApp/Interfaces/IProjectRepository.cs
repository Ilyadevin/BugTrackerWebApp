using BugTrackerWebApp.Data.Enum;
using BugTrackerWebApp.Models;

namespace BugTrackerWebApp.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAll();
        Task<Project> GetByIdAsync(int id);
        bool Add(Project project);
        bool Update(Project project);
        bool Delete(Project project);
        bool Save();
    }
}

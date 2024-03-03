using BugTrackerWebApp.Data.Enum;
using BugTrackerWebApp.Models;

namespace BugTrackerWebApp.Interfaces
{
    public interface IBugRepository
    {
        Task<IEnumerable<Bug>> GetAll();
        Task<Bug> GetByIdAsync(int id);
        Task<Bug> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<Bug>> GetBugByPriority(BugPriority bugPriority);
        bool Add(Bug bug);
        bool Update(Bug bug);  
        bool Delete(Bug bug);
        bool Save();
    }
}

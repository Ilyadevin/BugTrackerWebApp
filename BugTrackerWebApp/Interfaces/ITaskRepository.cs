using BugTrackerWebApp.Data.Enum;
using BugTrackerWebApp.Models;

namespace BugTrackerWebApp.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Task_>> GetAll();
        Task<Task_> GetByIdAsync(int id);
        Task<IEnumerable<Task_>> GetTaskByCompletition(TaskStatuses taskStatuses);
        bool Add(Task_ task);
        bool Update(Task_ task);
        bool Delete(Task_ task);
        bool Save();
    }
}

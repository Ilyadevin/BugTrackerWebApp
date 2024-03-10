using BugTrackerWebApp.Data;
using BugTrackerWebApp.Data.Enum;
using BugTrackerWebApp.Interfaces;
using BugTrackerWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTrackerWebApp.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Task_ task)
        {
            _context.Add(task);
            return Save();
        }

        public bool Delete(Task_ task)
        {
            _context.Remove(task);
            return Save();
        }

        public async Task<IEnumerable<Task_>> GetAll()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Task_> GetByIdAsync(int id)
        {
            return await _context.Tasks.FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<Task_> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Tasks.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }


        public async Task<IEnumerable<Task_>> GetTaskByCompletition(TaskStatuses taskStatuses)
        {
            return await _context.Tasks.Where(i => i.Status.Equals(taskStatuses)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Task_ task)
        {
            _context.Update(task);
            return Save();
        }
    }
}

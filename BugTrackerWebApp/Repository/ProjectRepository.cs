using BugTrackerWebApp.Data;
using BugTrackerWebApp.Interfaces;
using BugTrackerWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTrackerWebApp.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Project project)
        {
            _context.Add(project);
            return Save();
        }

        public bool Delete(Project project)
        {
            _context.Remove(project);
            return Save();
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await _context.Projects.FirstOrDefaultAsync(i => i.Id == id);

        }
        public async Task<Project> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Tasks.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Project project)
        {
            _context.Update(project);
            return Save();
        }
    }
}

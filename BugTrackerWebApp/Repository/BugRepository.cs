using BugTrackerWebApp.Data;
using BugTrackerWebApp.Data.Enum;
using BugTrackerWebApp.Interfaces;
using BugTrackerWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BugTrackerWebApp.Repository
{
    public class BugRepository : IBugRepository
    {
        private readonly ApplicationDbContext _context;

        public BugRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Bug bug)
        {
            _context.Add(bug);
            return Save();
        }

        public bool Delete(Bug bug)
        {
            _context.Remove(bug);
            return Save();
        }

        public async Task<IEnumerable<Bug>> GetAll()
        {
            return await _context.Bugs.ToListAsync();
        }

        public async Task<IEnumerable<Bug>> GetBugByPriority(BugPriority bugPriority)
        {
            return await _context.Bugs.Where(i => i.Criticality == bugPriority).ToListAsync();
        }

        public async Task<Bug> GetByIdAsync(int id)
        {
            return await _context.Bugs.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved>0?true: false;
        }

        public bool Update(Bug bug)
        {
            _context.Update(bug);
            return Save();
        }
    }
}

//using System.Data.Entity.Migrations;

//namespace BugTrackerWebApp.Data
//{
//    internal sealed class Configuration : DbMigrationsConfiguration<MyApplicationDbContext>
//    {
//        public Configuration()
//        {
//            AutomaticMigrationsEnabled = false;
//        }

//        protected override void Seed(MyApplicationDbContext _context)
//        {
//            // Seed AppUsers
//            foreach (var user in SeedData.GetAppUsers())
//            {
//                _context.AppUsers.AddOrUpdate(u => u.Email, user);
//            }

//            // Seed Projects
//            foreach (var project in SeedData.GetProjects())
//            {
//                _context.Projects.AddOrUpdate(p => p.Name, project);
//            }

//            // Seed Bugs
//            foreach (var bug in SeedData.GetBugs(_context))
//            {
//                _context.Bugs.AddOrUpdate(b => b.Title, bug);
//            }

//            // Seed Tasks
//            foreach (var task in SeedData.GetTasks(_context))
//            {
//                _context.Tasks.AddOrUpdate(t => t.Title, task);
//            }

//            _context.SaveChanges();
//        }
//    }
//}

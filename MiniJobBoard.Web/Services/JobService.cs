using System.Collections.Generic;
using System.Linq;
using MiniJobBoard.Web.Data;
using MiniJobBoard.Web.Models;
using MiniJobBoard.Web.Services.Interfaces;

namespace MiniJobBoard.Web.Services
{
    public class JobService : IJobService
    {
        private readonly AppDbContext _context;

        public JobService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Job> GetAllJobs()
        {
            return _context.Jobs.ToList();
        }

        public Job? GetJobById(int id)
        {
            return _context.Jobs.FirstOrDefault(j => j.Id == id);
        }

        public void AddJob(Job job)
        {
            _context.Jobs.Add(job);
            _context.SaveChanges();
        }
    }
}

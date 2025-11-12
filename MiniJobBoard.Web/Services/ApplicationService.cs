using MiniJobBoard.Web.Data;
using MiniJobBoard.Web.Models;
using MiniJobBoard.Web.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MiniJobBoard.Web.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly AppDbContext _context;

        public ApplicationService(AppDbContext context)
        {
            _context = context;
        }

        public void AddApplication(Application application)
        {
            _context.Applications.Add(application);
            _context.SaveChanges();
        }

        public IEnumerable<Application> GetAllApplications()
        {
            return _context.Applications
                .Include(a => a.Job)
                .ToList();
        }

        public IEnumerable<Application> GetApplicationsByJobId(int jobId)
        {
            return _context.Applications
                .Where(a => a.JobId == jobId)
                .Include(a => a.Job)
                .ToList();
        }
    }
}

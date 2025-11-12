using System.Collections.Generic;
using MiniJobBoard.Web.Models;

namespace MiniJobBoard.Web.Services.Interfaces
{
    public interface IJobService
    {
        IEnumerable<Job> GetAllJobs();
        Job? GetJobById(int id);
        void AddJob(Job job);
    }
}

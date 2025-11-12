using MiniJobBoard.Web.Models;
using System.Collections.Generic;

namespace MiniJobBoard.Web.Services.Interfaces
{
    public interface IApplicationService
    {
        void AddApplication(Application application);
        IEnumerable<Application> GetAllApplications();
        IEnumerable<Application> GetApplicationsByJobId(int jobId);
    }
}

using Microsoft.AspNetCore.Mvc;
using MiniJobBoard.Web.Models;
using MiniJobBoard.Web.Services.Interfaces;

namespace MiniJobBoard.Web.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly IApplicationService _applicationService;

        public ApplicationsController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public IActionResult Apply(int jobId)
        {
            var application = new Application { JobId = jobId };
            return View(application);
        }

        [HttpPost]
        public IActionResult Apply(Application application)
        {
            if (ModelState.IsValid)
            {
                _applicationService.AddApplication(application);
                TempData["SuccessMessage"] = "Application submitted Successfully!";
                return RedirectToAction("Index");
            }

            return View(application);
        }

        public IActionResult Index()
        {
            var applications = _applicationService.GetAllApplications();
            return View(applications);
        }

        public IActionResult ViewApplications(int jobId)
        {
            var applications = _applicationService.GetApplicationsByJobId(jobId);
            return View(applications);
        }
    }
}

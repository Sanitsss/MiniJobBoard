using Microsoft.AspNetCore.Mvc;
using MiniJobBoard.Web.Models;
using MiniJobBoard.Web.Services.Interfaces;

namespace MiniJobBoard.Web.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        public IActionResult Index()
        {
            var jobs = _jobService.GetAllJobs();
            return View(jobs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Job job)
        {
            if (ModelState.IsValid)
            {
                _jobService.AddJob(job);
                return RedirectToAction("Index");
            }
            return View(job);
        }

        public IActionResult Details(int id)
        {
            var job = _jobService.GetJobById(id);
            if (job == null)
                return NotFound();

            return View(job);
        }
    }
}

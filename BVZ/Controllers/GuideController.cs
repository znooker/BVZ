using BVZ.BVZ.Application.Services;
using BVZ.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BVZ.Controllers
{
    public class GuideController : Controller
    {
        private readonly ILogger<GuideController> _logger;
        private readonly GuideServices _guideServices;

        public GuideController(
            ILogger<GuideController> logger,
            GuideServices guideServices)
        {
            _logger = logger;
            _guideServices = guideServices;
        }

        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
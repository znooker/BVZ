using BVZ.BVZ.Application.Services;
using BVZ.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BVZ.Controllers
{
    public class ZooController : Controller
    {
        private readonly ILogger<ZooController> _logger;
        private readonly MockTourService _service;

        public ZooController(
            ILogger<ZooController> logger,
            MockTourService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            _service.NewDay();
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
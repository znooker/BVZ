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

        public async Task<IActionResult> Index()
        {
            var serviceResponse = await _service.NewDay();
            if (serviceResponse.IsSuccess)
            {
                // skapa ViwModel för success
                return View();
            }
            else
            {
                // skapa ViwModel för error
                return View();
            }

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
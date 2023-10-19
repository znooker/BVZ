using BVZ.BVZ.Application.Services;
using BVZ.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BVZ.Controllers
{
    public class ZooController : Controller
    {
        private readonly ILogger<ZooController> _logger;
        private readonly TourService _tourService;

        public ZooController(
            ILogger<ZooController> logger,
            TourService tourService)
        {
            _logger = logger;
            _tourService = tourService;
        }

        public async Task<IActionResult> Index()
        {
            DateTime date = DateTime.Today.AddDays(1);
            var serviceResponse = await _tourService.NewDay(date);
            if (serviceResponse.IsSuccess)
            {
                // skapa ViwModel för success
                return View();
            }
            else
            {
                string ss = serviceResponse.ErrorMessage;
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
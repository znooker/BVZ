using BVZ.BVZ.Application;
using BVZ.BVZ.Application.Services;
using BVZ.Models;
using BVZ.Models.Tour;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BVZ.Controllers
{
    public class TourController : Controller
    {
        private readonly ILogger<TourController> _logger;
        private readonly TourService _tourService;

        public TourController(
            ILogger<TourController> logger,
            TourService tourService)
        {
            _logger = logger;
            _tourService = tourService;
        }

        public async Task<IActionResult> Index()
        {
            var getTours = await _tourService.GetCurrentDayZooTours(DateTime.Today);
            if(!getTours.IsSuccess)
            {
                ErrorViewModel ewm = new ErrorViewModel();
                ewm.ValidationErrorMessage = "Det gick inte att hitta några " +
                    "tillgängliga turer för det aktuella datumet.";
                return View(ewm);
            }
            DisplayAllToursViewModel displayVM = new DisplayAllToursViewModel 
            { 
                ToursOfTheDay = getTours.Data 
            };

            return View(displayVM);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using BVZ.BVZ.Application;
using BVZ.BVZ.Application.Services;
using BVZ.BVZ.Domain.Models.Visitors;
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

        [HttpPost]
        public async Task<IActionResult> BookTour(Guid Id, int NrOfPersons)
        {
            // Service anrop för att se om plats finns för denna.
            var response = await _tourService.BookZooTour(Id, NrOfPersons);


            BookingConfirmationViewModel bcVM = new BookingConfirmationViewModel
            {
                BookingSuccessful = true,
                UserMessage = "Det här gick kanon!"
            };
            return View("/views/Tour/index.cshtml", bcVM);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
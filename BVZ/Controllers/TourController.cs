using Azure.Core;
using BVZ.BVZ.Application;
using BVZ.BVZ.Application.Services;
using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.Models;
using BVZ.Models.Tour;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            if (!getTours.IsSuccess)
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
        public async Task<IActionResult> BookTour(Guid Id, int NrOfPersons, List<string>? PersonNames)
        {
            // Service anrop för att se om plats finns för denna.
            var response = await _tourService.BookZooTour(Id, NrOfPersons, PersonNames);

            if(!response.IsSuccess)
            {
                ErrorViewModel eVM = new ErrorViewModel();

                if (response.UserInfo != null)
                {
                    eVM.ValidationErrorMessage = response.UserInfo;
                    return View("/views/Tour/index.cshtml", eVM);
                }
                if (response.ErrorMessage != null)
                {
                    eVM.RequestId = response.ErrorMessage;
                    return RedirectToAction("Error", "Home", eVM);
                }        
            }

            BookingConfirmationViewModel bcVM = new BookingConfirmationViewModel
            {
                BookingSuccessful = true,
                Visitors = response.Data
            };

            return View("/views/Tour/BookingConfirmation.cshtml", bcVM);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
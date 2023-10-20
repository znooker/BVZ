using BVZ.BVZ.Application.Services;
using BVZ.Models.Tour;
using BVZ.Models;
using Microsoft.AspNetCore.Mvc;

namespace BVZ.Controllers
{
    public class AdminTourController : Controller
    {

        private readonly ILogger<AdminTourController> _logger;
        private readonly TourService _tourService;

        public AdminTourController(
            ILogger<AdminTourController> logger,
            TourService tourService)
        {
            _logger = logger;
            _tourService = tourService;
        }
        public async Task<IActionResult> Index()
        {
            
            var getAllTours = await _tourService.GetAllTours();
            if (!getAllTours.IsSuccess)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel();
                errorViewModel.ValidationErrorMessage = "Det gick inte att hämta några tours";
                return View(errorViewModel);
            }
            DisplayAllToursViewModel displayVM = new DisplayAllToursViewModel
            {
                AllTours = getAllTours.Data
            };
            return View(displayVM);
            
            //var getTours = await _tourService.GetCurrentDayZooTours(DateTime.Today);
            //if (!getTours.IsSuccess)
            //{
            //    ErrorViewModel ewm = new ErrorViewModel();
            //    ewm.ValidationErrorMessage = "Det gick inte att hitta några " +
            //        "tillgängliga turer för det aktuella datumet.";
            //    return View(ewm);
            //}
            //DisplayAllToursViewModel displayVM = new DisplayAllToursViewModel
            //{
            //    ToursOfTheDay = getTours.Data
            //};

            //return View(displayVM);
        }
    }
}

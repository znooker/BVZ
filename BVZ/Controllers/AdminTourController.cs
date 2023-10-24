using BVZ.BVZ.Application.Services;
using BVZ.Models.Tour;
using BVZ.Models;
using Microsoft.AspNetCore.Mvc;
using BVZ.BVZ.Domain.Models.Visitors;
using System.Runtime.InteropServices;
using BVZ.Models.Admin;

namespace BVZ.Controllers
{
    public class AdminTourController : Controller
    {

        private readonly ILogger<AdminTourController> _logger;
        private readonly TourService _tourService;
        private readonly GuideServices _guideServices;

        public AdminTourController(
            ILogger<AdminTourController> logger,
            TourService tourService, GuideServices guideServices)
        {
            _logger = logger;
            _tourService = tourService;
            _guideServices = guideServices;
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
            
        }

        public async Task<IActionResult> Create()
        {
            
            var getAllGuides = await _guideServices.GetAllGuides();
            if (!getAllGuides.IsSuccess)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel();
                errorViewModel.ValidationErrorMessage = "Fel vid laddning av guider";
                return View(errorViewModel);
            }

            var createTourVm = new AdminCreateTourViewModel()
            {
                Guides = getAllGuides.Data
            };

            return View("/Views/AdminTour/CreateTour.cshtml",createTourVm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminCreateTourViewModel newTour)
        {
            var response = await _tourService.CreateNewTour(newTour);

            return View("/Views/AdminTour/CreateTourConfirmation.cshtml", response.Data);

        }
    }
}

using BVZ.BVZ.Application.Services;
using BVZ.Models.Tour;
using BVZ.Models;
using Microsoft.AspNetCore.Mvc;
using BVZ.BVZ.Domain.Models.Visitors;
using System.Runtime.InteropServices;
using BVZ.Models.Admin;
//using AspNetCore;
using BVZ.BVZ.Application;
using Microsoft.Extensions.Options;

namespace BVZ.Controllers
{
    public class AdminTourController : Controller
    {

        private readonly ILogger<AdminTourController> _logger;
        private readonly TourService _tourService;
        private readonly GuideServices _guideServices;
        private readonly AnimalServices _animalServices;

        public AdminTourController(
            ILogger<AdminTourController> logger,
            TourService tourService,
            GuideServices guideServices,
            AnimalServices animalServices)
        {
            _logger = logger;
            _tourService = tourService;
            _guideServices = guideServices;
            _animalServices = animalServices;
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

        
        public async Task<IActionResult> SelectGuideCompetence()
        {
            var getOptions = await _animalServices.GetAllAnimalTypes();
            if (!getOptions.IsSuccess)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel();
                errorViewModel.ValidationErrorMessage = "Fel vid laddnig av kompetensval";
                return View(errorViewModel);
            }

            var optionsVM = new GuideCompetenceSelectVM()
            {
                AvailableOptions = getOptions.Data
            };

            return View("/Views/AdminTour/SelectGuideCompetence.cshtml",optionsVM);
            
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

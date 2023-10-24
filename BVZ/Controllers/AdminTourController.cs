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
using BVZ.Models.Guide;

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

        
        public async Task<IActionResult> SelectGuide()
        {
            var getAllGuides = await _guideServices.GetAllGuides();
            if (!getAllGuides.IsSuccess)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel();
                errorViewModel.ValidationErrorMessage = "Det gick inte att hämta ut några guider";
                return View(errorViewModel);
            }

            DisplayAllGuidesViewModel displayVm = new DisplayAllGuidesViewModel
            {
                Guides = getAllGuides.Data
            };


            return View("/Views/AdminTour/SelectGuide.cshtml",displayVm);

        }

        [HttpPost]
        public async Task<IActionResult> CreateStepOne(DisplayAllGuidesViewModel data)
        {
            var t = data.SelectedGuideID;
            var getSelectGuide = await _guideServices.GetGuideById(data.SelectedGuideID);
            if (!getSelectGuide.IsSuccess)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel();
                errorViewModel.ValidationErrorMessage = "Fel vid hämtning av guide.";
                return View(errorViewModel);
            }

            var createTourVm = new DisplayAdminAnimalsViewModel()
            {
                Guide = getSelectGuide.Data
            };

            return View("/Views/AdminTour/CreateTour.cshtml", createTourVm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminCreateTourViewModel inputData)
        {
            
            var newTour = await _tourService.CreateNewTour(inputData);
            if(!newTour.IsSuccess)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel();
                errorViewModel.ValidationErrorMessage = newTour.ErrorMessage;
                return View("/Views/AdminTour/CreateTourConfirmation.cshtml",errorViewModel);
            }

            return View("/Views/AdminTour/CreateTourConfirmation.cshtml", newTour.Data);

        }
    }
}

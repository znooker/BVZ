using BVZ.BVZ.Application.Services;
using BVZ.Models.Tour;
using BVZ.Models;
using Microsoft.AspNetCore.Mvc;
using BVZ.BVZ.Domain.Models.Visitors;
using System.Runtime.InteropServices;
using BVZ.Models.Admin;
using BVZ.BVZ.Application;
using Microsoft.Extensions.Options;
using BVZ.Models.Admin.Guide;
using BVZ.Models.Admin.Tour;


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
                errorViewModel.ValidationErrorMessage = getAllTours.UserInfo;
                return View(errorViewModel);
            }

            DisplayAllToursViewModel displayVM = new DisplayAllToursViewModel
            {
                AllTours = getAllTours.Data
            };

            if (TempData["Message"] != null && TempData["Status"] != null)
            {
                string messageToStr = TempData["Message"].ToString();
                string statusToStr = TempData["Status"].ToString();
                displayVM.Message = messageToStr;
                displayVM.Status = statusToStr;
            }

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


            return View("/Views/AdminTour/SelectGuide.cshtml", displayVm);

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
        public async Task<IActionResult> Create(DisplayAdminAnimalsViewModel inputData)
        {

            var newTour = await _tourService.CreateNewTour(inputData);
            if (!newTour.IsSuccess)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel();
                errorViewModel.ValidationErrorMessage = newTour.ErrorMessage;
                return View("/Views/AdminTour/CreateTourConfirmation.cshtml", errorViewModel);
            }

            return View("/Views/AdminTour/CreateTourConfirmation.cshtml", newTour.Data);

        }

        [HttpPost]
        public async Task<IActionResult> SoftDeleteTour(Guid tourId)
        {
            var selectedTour = await _tourService.SoftDeleteTour(tourId);

            if (!selectedTour.IsSuccess)
            {
                ErrorViewModel eVm = new ErrorViewModel
                {
                    ValidationErrorMessage = selectedTour.ErrorMessage
                };
                return View(eVm);
            }

            string deleteMessage = selectedTour.Data;
            TempData["Message"] = deleteMessage;
            TempData["Status"] = "delete";
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> UpdateTourFormRedirect(Guid tourId)
        {
            var tour = await _tourService.GetSingleTourById(tourId);

            if (!tour.IsSuccess)
            {
                ErrorViewModel eVm = new ErrorViewModel
                {
                    ValidationErrorMessage = tour.ErrorMessage
                };

            }

            SingleTourViewModel stVM = new SingleTourViewModel { Tour = tour.Data };
            return View("UpdateTourForm", stVM);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateTour(Guid tourId, string tourName, string tourDescription)
        {
            var selectedTour = await _tourService.UpdateTour(tourId, tourName, tourDescription);
            if (!selectedTour.IsSuccess)
            {
                ErrorViewModel eVm = new ErrorViewModel
                {
                    ValidationErrorMessage = selectedTour.ErrorMessage
                };
            }

            string updateMessage = selectedTour.Data;
            TempData["Message"] = updateMessage;
            TempData["Status"] = "update";
            return RedirectToAction("Index");

        }
    }
}

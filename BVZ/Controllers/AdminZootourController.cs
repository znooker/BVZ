using BVZ.BVZ.Application.Services;
using BVZ.Models;
using BVZ.Models.Admin;
using Microsoft.AspNetCore.Mvc;

namespace BVZ.Controllers
{
    public class AdminZootourController : Controller
    {
        private readonly TourService _tourService;

        public AdminZootourController(
            TourService tourService)
        {
            _tourService = tourService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _tourService.GetAvailableTours();
            AdminZootourViewModel azVM = new AdminZootourViewModel
            {
                AvailableTours = result.Data,
            };

            if (TempData["Message"] != null)
            {
                string messageToStr = TempData["Message"].ToString();
                azVM.Message = messageToStr;
            }
            return View(azVM);
        }

        public async Task<IActionResult> NrOfTours(Guid tourId)
        {
            var result = await _tourService.GetSchedeuleTourOptions(tourId);
            TimeOfTourViewModel ttVM = new TimeOfTourViewModel
            {
                Id = tourId,
            };

            if(result.Data == 1) 
            {
                ttVM.morning = true;
                ttVM.afternoon = false;
            }
            if (result.Data == 2) 
            { 
                ttVM.afternoon = true;
                ttVM.morning = false;
            }
            if (result.Data == 3) 
            {
                ttVM.morning = true;
                ttVM.afternoon = true; 
            }

            return View("index", ttVM);
        }

        public async Task<IActionResult> SchedeuleTour(Guid id, string? morning, string? afternoon)
        {
            if( morning == null && afternoon == null)
            {
                ErrorViewModel eVM = new ErrorViewModel
                {
                    ValidationErrorMessage = "Kan inte boka någon tur om varken morgon eller eftermiddagstur är vald."
                };
                 return View("index", eVM);
            }
            
            var result = await _tourService.SchedeuleDailyTours(id, morning, afternoon);
            if(!result.IsSuccess)
            {
                ErrorViewModel eVM = new ErrorViewModel
                {
                    ValidationErrorMessage = result.UserInfo
                };
                return View("index", eVM);
            }

            string message = result.Data;
            TempData["Message"] = message;
            return RedirectToAction("Index");
        }






        //public async Task<IActionResult> AddAnimalRegistration()
        //{
        //    var result = await _animalServices.GetAllAnimals();

        //    if (!result.IsSuccess)
        //    {
        //        ErrorViewModel eVM = new ErrorViewModel
        //        {
        //            ValidationErrorMessage = result.ErrorMessage,
        //        };
        //    }
        //    DisplayAdminAnimalsViewModel daaVM = new DisplayAdminAnimalsViewModel
        //    {
        //        Animals = result.Data
        //    };

        //    return View("AddAnimalForm", daaVM);
        //}
    }
}

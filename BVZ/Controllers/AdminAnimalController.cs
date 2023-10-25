using BVZ.BVZ.Application.Services;
using BVZ.BVZ.Domain.Models.Zoo.Animals;
using BVZ.Models;
using BVZ.Models.Admin.Animals;
using Microsoft.AspNetCore.Mvc;
using static BVZ.BVZ.Domain.Models.Zoo.Animals.Animal;

namespace BVZ.Controllers
{
    public class AdminAnimalController : Controller
    {
        private readonly AnimalServices _animalServices;

        public AdminAnimalController(
            AnimalServices animalServices)
        {
            _animalServices = animalServices;
        }

        public async Task<IActionResult> Index(string? message)
        {
            var result = await _animalServices.GetAllAnimals();
            
            if(!result.IsSuccess) 
            {
                ErrorViewModel eVM = new ErrorViewModel
                {
                    ValidationErrorMessage = result.ErrorMessage,
                };
            }
            DisplayAdminAnimalsViewModel daaVM = new DisplayAdminAnimalsViewModel
            {
                Animals = result.Data
            };

            if (TempData["Message"] != null && TempData["Status"] != null)
            {
                string messageToStr = TempData["Message"].ToString();
                string statusToStr = TempData["Status"].ToString();
                daaVM.Message = messageToStr;
                daaVM.Status = statusToStr;
            }
            return View(daaVM);
        }

        public async Task<IActionResult> AddAnimalRegistration()
        {
            var result = await _animalServices.GetAllAnimalTypes();

            if (!result.IsSuccess)
            {
                ErrorViewModel eVM = new ErrorViewModel
                {
                    ValidationErrorMessage = result.ErrorMessage,
                };
            }
            DisplayAdminAnimalsViewModel daaVM = new DisplayAdminAnimalsViewModel
            {
                AnimalTypes = result.Data
            };

            return View("AddAnimalForm", daaVM);
        }

        public async Task<IActionResult> AddAnimal(string animalType, string animalName)
        {
            
            var result = await _animalServices.AddAnimal(animalType, animalName);
            if (!result.IsSuccess)
            {
                ErrorViewModel eVM = new ErrorViewModel
                {
                    ValidationErrorMessage = result.UserInfo,
                };
                return View(eVM);
            }

            string message = result.Data;
            TempData["Message"] = message;
            TempData["Status"] = "add";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ViewAnimal(Guid animalId)
        {
            var result = await _animalServices.GetAnimalById(animalId);
            if (!result.IsSuccess)
            {
                ErrorViewModel eVM = new ErrorViewModel
                {
                    ValidationErrorMessage = result.UserInfo,
                };
                return View(eVM);
            }
            return RedirectToAction("Details", "Home", new { result.Data.Id });
        }


        public async Task<IActionResult> UpdateAnimalRedirect(Guid animalId)
        {
            var result = await _animalServices.GetAnimalById(animalId);

            if (!result.IsSuccess)
            {
                ErrorViewModel eVM = new ErrorViewModel
                {
                    ValidationErrorMessage = result.ErrorMessage,
                };
            }
            SingleAnimalViewModel saVM = new SingleAnimalViewModel { Animal = result.Data };
            return View("UpdateAnimalForm", saVM);
        }

        public async Task<IActionResult> UpdateAnimal(Guid animalId, string animalName)
        {
            var result = await _animalServices.UpdateAnimal(animalId, animalName);

            if (!result.IsSuccess)
            {
                ErrorViewModel eVM = new ErrorViewModel
                {
                    ValidationErrorMessage = result.UserInfo,
                };
            }

            string message = result.Data;
            TempData["Message"] = message;
            TempData["Status"] = "update";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteAnimal(Guid animalId)
        {
            var result = await _animalServices.DeleteAnimal(animalId);
            if(!result.IsSuccess) 
            {
                ErrorViewModel eVM = new ErrorViewModel
                {
                    ValidationErrorMessage = result.UserInfo,
                };
                return View(eVM);
            }

            string message = result.Data;
            TempData["Message"] = message;
            TempData["Status"] = "delete";
            return RedirectToAction("Index"); 
        }
    }
    
}

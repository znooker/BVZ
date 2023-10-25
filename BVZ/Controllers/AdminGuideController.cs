using BVZ.BVZ.Application.Services;
using BVZ.BVZ.Domain.Models.Zoo.Guides;
using BVZ.Models;
using BVZ.Models.Admin.Guide;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Reflection.Metadata.Ecma335;
using System.Security.Permissions;

namespace BVZ.Controllers
{
    public class AdminGuideController : Controller
    {
        private readonly ILogger<AdminGuideController> _logger;
        private readonly GuideServices _guideServices;
        private readonly AnimalServices _animalServices;

        public AdminGuideController(
            ILogger<AdminGuideController> logger,
            GuideServices guideServices,
            AnimalServices animalServices)
        {
            _logger = logger;
            _guideServices = guideServices;
            _animalServices=animalServices;
        }
        public async Task<IActionResult> Index()
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

            if (TempData["Message"] != null && TempData["Status"] != null)
            {
                string messageToStr = TempData["Message"].ToString();
                string statusToStr = TempData["Status"].ToString();
                displayVm.Message = messageToStr;
                displayVm.Status = statusToStr;
            }

            return View(displayVm);

        }

        public async Task<IActionResult> SoftDeleteGuide(Guid guideId)
        {
            var selectedGuide = await _guideServices.SoftDeleteGuide(guideId);
            if (!selectedGuide.IsSuccess) 
            {
                ErrorViewModel eVM = new ErrorViewModel
                {
                    ValidationErrorMessage = selectedGuide.ErrorMessage
                };
                return View(eVM);
            }

            string deleteMessage = selectedGuide.Data;
            TempData["Message"] = deleteMessage;
            TempData["Status"] = "delete";
            return RedirectToAction("Index");
        }

        //Döpa om till CreateGuideStepOne
        public async Task<IActionResult> SelectGuideCompetence()
        {
            var options = await _animalServices.GetUniqueAnimalListByAnimalType();

            if (!options.IsSuccess)
            {
                ErrorViewModel eVM = new ErrorViewModel
                {
                    ValidationErrorMessage = options.ErrorMessage
                };
                return View(eVM);
            }

            GuideCompetenceSelectViewModel gscVM = new GuideCompetenceSelectViewModel
            {
                CompetenceOptions = options.Data.Select(x => x.AnimalType.ToString()).ToList(),
            };

            return View("/Views/AdminGuide/HireGuideStepOneForm.cshtml", gscVM);

        }


        //Lär finnas fel här... gjorde detta kl 01.00
        [HttpPost]
        public async Task<IActionResult> CreateGuideStepTwo(GuideCompetenceSelectViewModel data)
        {
            var competenses = data.SelectedCompetences;
            var animals = await _animalServices.GetUniqueAnimalListByAnimalType(competenses);
            
            if (!animals.IsSuccess)
            {
                ErrorViewModel eVM = new ErrorViewModel
                {
                    ValidationErrorMessage = animals.ErrorMessage
                };

                return View("/Views/AdminGuide/HireGuideStepOneForm.cshtml",eVM);
            }

            GuideViewModel gVM = new GuideViewModel {
                AnimalCompetences = animals.Data
                
            };

            return View("/Views/AdminGuide/HireGuideStepTwoForm.cshtml", gVM);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGuide(GuideViewModel data)
        {
            //Kvar att göra, skapa Guiden och koppla ihop
            //Animal ID's med listan av animal IDs från
            //listan data.AnimalIDs

            var test = data;
            return RedirectToAction("Index");
        }
    }
}

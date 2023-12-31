﻿using BVZ.BVZ.Application.Services;
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
            var response = await _guideServices.CreateGuide(data);
            if (!response.IsSuccess)
            {
                ErrorViewModel eVM = new ErrorViewModel 
                {
                    ValidationErrorMessage = response.ErrorMessage

                };
                return RedirectToAction("Index", eVM);
            }
            
            string message = response.UserInfo;
            TempData["Message"] = message;
            TempData["Status"] = "add";
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> RedirectToUpdateGuideForm(Guid guideId)
        {
            var animals = await _animalServices.GetUniqueAnimalListByAnimalType();
            if (!animals.IsSuccess)
            {
                ErrorViewModel eVM = new ErrorViewModel
                {
                    ValidationErrorMessage = animals.ErrorMessage
                };
                return RedirectToAction("Index", eVM);
            }
            var guide = await _guideServices.GetGuideById(guideId);
            if (!guide.IsSuccess)
            {
                ErrorViewModel eVM = new ErrorViewModel
                {
                    ValidationErrorMessage = guide.ErrorMessage
                };
                return RedirectToAction("Index", eVM);
            }

            GuideViewModel gVm = new GuideViewModel
            {
                GuideName = guide.Data.Name,
                Guide = guide.Data,
                CurrentAnimalCompetences = guide.Data.AnimalCompetences.Select(x => x.Animal).ToList(),
                CompetenceOptions = animals.Data.Select(x => x.AnimalType).ToList()
            };

            return View("/Views/AdminGuide/UpdateGuideForm.cshtml", gVm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGuide(GuideViewModel guide)
        {
            var competences = guide.SelectedCompetences;
            var animals = await _animalServices.GetUniqueAnimalListByAnimalType(competences);

            if (!animals.IsSuccess)
            {
                ErrorViewModel eVM = new ErrorViewModel
                {
                    ValidationErrorMessage = animals.ErrorMessage
                };

                return RedirectToAction("Index", eVM);
            }

            var guideResult = await _guideServices.UpdateGuide(guide);
            if (!guideResult.IsSuccess)
            {
                ErrorViewModel eVM = new ErrorViewModel
                {
                    ValidationErrorMessage = guideResult.ErrorMessage
                };

                return RedirectToAction("Index", eVM);
            }



            var competenceResult = await _guideServices.UpdateGuideCompetence(guideResult.Data, animals.Data);

            if (!competenceResult.IsSuccess)
            {
                ErrorViewModel eVM = new ErrorViewModel
                {
                    ValidationErrorMessage = guideResult.ErrorMessage
                };

                return RedirectToAction("Index", eVM);
            }



            string updateMessage = competenceResult.UserInfo;
            TempData["Message"] = updateMessage;
            TempData["Status"] = "update";
            return RedirectToAction("Index");
        }
    }
}

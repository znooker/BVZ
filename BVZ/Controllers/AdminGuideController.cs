using BVZ.BVZ.Application.Services;
using BVZ.Models;
using BVZ.Models.Admin.Guide;
using Microsoft.AspNetCore.Mvc;

namespace BVZ.Controllers
{
    public class AdminGuideController : Controller
    {
        private readonly ILogger<AdminGuideController> _logger;
        private readonly GuideServices _guideServices;

        public AdminGuideController(
            ILogger<AdminGuideController> logger,
            GuideServices guideServices)
        {
            _logger = logger;
            _guideServices = guideServices;
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
    }
}

using BVZ.BVZ.Application.Services;
using BVZ.Models;
using BVZ.Models.Guide;
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


            return View(displayVm);

        }
    }
}

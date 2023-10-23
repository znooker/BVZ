using BVZ.BVZ.Application.Services;
using BVZ.Models;
using BVZ.Models.Admin;
using Microsoft.AspNetCore.Mvc;

namespace BVZ.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly VisitorServices _visitorServices;

        public AdminController(ILogger<AdminController> logger, VisitorServices visitorServices)
        {
            _logger=logger;
            _visitorServices=visitorServices;
        }

        public async Task<IActionResult> Index()
        {
            var visitorLinkedTours = await _visitorServices.GetAllVisitorsAndLinkedTours();

            if(!visitorLinkedTours.IsSuccess) 
            {
                ErrorViewModel errorViewModel = new ErrorViewModel();
                errorViewModel.ValidationErrorMessage = "Finns ingen data att hämta";
                return View(errorViewModel);
            }

            AllVisitorsAndLinkedToursViewModel displayVm = new AllVisitorsAndLinkedToursViewModel() 
            {
                VisitorAndTours = visitorLinkedTours.Data
            };

            return View(displayVm);
        }
    }
}

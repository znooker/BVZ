using BVZ.BVZ.Application.Services;
using BVZ.Models;
using BVZ.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BVZ.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AnimalServices _animalServices;

        public HomeController(ILogger<HomeController> logger, AnimalServices animalServices)
        {
            _logger = logger;
            _animalServices=animalServices;
        }

        public async Task<IActionResult> Index()
        {
            var animal= await _animalServices.GetAllAnimals();
            if (!animal.IsSuccess)
            {
                //Något gick fel ErrorViewModel...
                return View();
            }
            else
            {
                var viewModel = new HomeViewModel
                {
                    ZooAnimals = animal.Data.ToList()
                };
                return View(viewModel);
            }
            
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using BVZ.BVZ.Application.Services;
using BVZ.BVZ.Domain.Models.Zoo.Animals;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Air;
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
            var animal = await _animalServices.GetAllAnimals();
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

        public async Task<IActionResult> Details(Guid animalId)
        {
            var animal = await _animalServices.GetAnimalByIdTest(animalId);
            var hVM = new HomeViewModel
            {
                Animal = animal.Data
            };
            return View("/views/Home/index.cshtml", hVM);
        }
    }
}
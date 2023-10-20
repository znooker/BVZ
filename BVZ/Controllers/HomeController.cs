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
        
        
        //Gör till task, Async mm få in id från djuret
        
        public async Task<IActionResult> Details(Guid id)
        {
            var animal1 = await _animalServices.GetAnimalByIdTest(id);
            var animal = await _animalServices.GetAnimalById(id);
            if (!animal.IsSuccess)
            {
                //Något gick fel ErrorViewModel...
                return View();
            }
            else
            {

                //var viewModel = new BaldEagle
                //{
                //    Id = animal.Data.Id,
                //    AnimalName  = animal.Data.AnimalName,
                //    Specie = animal.Data.Specie

                //};
                var result = await _animalServices.DisplayAnimalPropertiesAndMethods(animal1.Data);
                return View();
            }
            //return View(animal);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
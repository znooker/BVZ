using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Domain.Models.Zoo.Animals;
using BVZ.BVZ.Domain.Models.Zoo;
using BVZ.BVZ.Infrastructure.Data;
using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Infrastructure.Repositories;

namespace BVZ.BVZ.Application.Services
{
    public class TourService
    {
        private readonly ILogger<TourService> _logger;
        private readonly ITourRepository _tourRepository;
        private readonly IZooRepository _zooRepository;

        public TourService(
            ILogger<TourService> logger,
            ITourRepository tourRepository,
            IZooRepository zooRepository)
        {
            _logger = logger;
            _tourRepository = tourRepository;
            _zooRepository = zooRepository;
        }

        /*Create new opening day of the zoo and add all available tours that day, 
        morning and afternoon-tours*/
        public async Task<ServiceResponse<List<ZooTour>>> NewDay(DateTime newDayDate)
        {
            ServiceResponse<List<ZooTour>> response = new ServiceResponse<List<ZooTour>>();
            ZooDay zooDay = new ZooDay();
            zooDay.TodaysDate = newDayDate;
            _zooRepository.AddNewZooDay(zooDay);

            var tours = await _tourRepository.GetAllTours();
            if (tours == null)
            {
                response.IsSuccess = false;
                response.ErrorMessage = "List of tours is null or empty.";
                return response;
            }

            List<ZooTour> DailyBookableTours = new List<ZooTour>();
            foreach (var tour in tours)
            {
                if (tour.Guide.IsUnavailable == true)
                {
                    response.UserInfo = "Guide is unavailable for " + tour.TourName;
                    break; 
                }
                
                var twoDailyTours = await tour.CreateDailyTours(tour, zooDay);
                if (twoDailyTours != null)
                {
                    foreach (var singleTour in twoDailyTours)
                    {
                        _tourRepository.AddZooTour(singleTour);
                        DailyBookableTours.Add(singleTour);
                    }
                }
                else break;
            }
            response.IsSuccess = true;
            response.Data = DailyBookableTours;
            return response;
        }

        public async Task<ServiceResponse<List<ZooTour>>>GetCurrentDayZooTours(DateTime currentDate)
        {
            ServiceResponse<List<ZooTour>> response = new ServiceResponse<List<ZooTour>>();

            var list = await _tourRepository.GetZooToursByDate(currentDate);
            if(list == null) 
            {
                response.IsSuccess = false;
                response.ErrorMessage = "Det finns inga turer den här dagen.";
                return response;
            }
            response.IsSuccess = true;
            response.Data = list;
            return response;
        }

        public void BookTour(ZooTour zootour)
        {
            // kolla animals
            var guide = zootour.Tour.Guide;
            List<Animal> AnimalsVisited = new List<Animal>();
            foreach (var comp in guide.AnimalCompetences)
            {
                AnimalsVisited.Add(comp.Animal);
            }

            // Method checking each animal
            // if(Animal.AnimalVisit.ZooDay.TodaysDate < 2)
            // Ok för att boka tour.

            // Skapa ny AnimalVisit för varje animal i AnimalsVisited.

            ZooDay zooDay = new ZooDay();

            //var tours =.Tours.ToList();
            //CreateZooTours(zooDay, tours);

        }
    }
}


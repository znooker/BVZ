using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Domain.Models.Zoo.Animals;
using BVZ.BVZ.Domain.Models.Zoo;
using BVZ.BVZ.Infrastructure.Data;
using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Infrastructure.Repositories;
using BVZ.BVZ.Application;
using System.Collections.Generic;
using BVZ.BVZ.Domain.Models.Zoo.Guides;

namespace BVZ.BVZ.Application.Services
{
    public class TourService
    {
        private readonly ILogger<TourService> _logger;
        private readonly ITourRepository _tourRepository;
        private readonly IGuideRepository _guideRepository;

        public TourService(
            ILogger<TourService> logger,
            ITourRepository tourRepository,
            IGuideRepository guideRepository)
        {
            _logger = logger;
            _tourRepository = tourRepository;
            _guideRepository = guideRepository;
        }

        public async Task<ServiceResponse<bool>> BookZooTour(Guid zooTourId, int NrOfPersonsToBook)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();

            var zootour = await _tourRepository.GetZooTourById(zooTourId);

            CheckAnimalFatigueInTour(zootour.Tour.GuideId);



            if (zootour == null) 
            {
                response.IsSuccess = false;
                response.ErrorMessage = "Något är fel med turen, försök boka igen.";
                return response;
            }

             if((zootour.NrOfParticipants + NrOfPersonsToBook) > 5)
            {
                response.IsSuccess = false;
                response.UserInfo = "För många personer, max 5 personer per bokad tur. Det är redan" + zootour.NrOfParticipants + " personer bokade.";
                return response;
            }
            zootour.NrOfParticipants += NrOfPersonsToBook;
            if (!await _tourRepository.UpdateZooTour(zootour))
            {
                response.IsSuccess = false;
                response.ErrorMessage = "Fel i databas, försök igen senare.";
                return response;
            }
            response.IsSuccess = true; 
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

        private async Task<bool> CheckAnimalFatigueInTour(Guid guideId)
        {
            var animalsIds = await _guideRepository.GetAnimalsByGuideId(guideId);

            foreach (var animalId in animalsIds)
            {
                // int nrOfVisits = _animalRepository.GetAnimalVisitsByDateAndAnimal();
            }
            return true;
            // var guide = zootour.Tour.Guide;
            //List<Animal> AnimalsVisited = new List<Animal>();
            //foreach (var comp in guide.AnimalCompetences)
            //{
            //    AnimalsVisited.Add(comp.Animal);
            //}

            // Method checking each animal
            // if(Animal.AnimalVisit.ZooDay.TodaysDate < 2)
            // Ok för att boka tour.

            // Check animals in tour

        }

    }
}




///*Create new opening day of the zoo and add all available tours that day, 
//        morning and afternoon-tours*/
//public async Task<ServiceResponse<List<ZooTour>>> NewDay(DateTime newDayDate)
//{
//    ServiceResponse<List<ZooTour>> response = new ServiceResponse<List<ZooTour>>();
//    ZooDay zooDay = new ZooDay();
//    zooDay.TodaysDate = newDayDate;
//    _zooRepository.AddNewZooDay(zooDay);

//    var tours = await _tourRepository.GetAllTours();
//    if (tours == null)
//    {
//        response.IsSuccess = false;
//        response.ErrorMessage = "List of tours is null or empty.";
//        return response;
//    }

//    List<ZooTour> DailyBookableTours = new List<ZooTour>();
//    foreach (var tour in tours)
//    {
//        if (tour.Guide.IsUnavailable == true)
//        {
//            response.UserInfo = "Guide is unavailable for " + tour.TourName;
//            break;
//        }

//        var twoDailyTours = await tour.CreateDailyTours(tour, zooDay);
//        if (twoDailyTours != null)
//        {
//            foreach (var singleTour in twoDailyTours)
//            {
//                _tourRepository.AddZooTour(singleTour);
//                DailyBookableTours.Add(singleTour);
//            }
//        }
//        else break;
//    }
//    response.IsSuccess = true;
//    response.Data = DailyBookableTours;
//    return response;
//}
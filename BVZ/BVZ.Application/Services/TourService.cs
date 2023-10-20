using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Domain.Models.Zoo;
using BVZ.BVZ.Domain.Models.Zoo.Animals;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BVZ.BVZ.Application.Services
{
    public class TourService
    {
        private readonly ILogger<TourService> _logger;
        private readonly ITourRepository _tourRepository;
        private readonly IGuideRepository _guideRepository;
        private readonly IAnimalRepository _animalRepository;
        private readonly IZooRepository _zooRepository;
        private readonly ITransaction _baseRepository;

        public TourService(
            ILogger<TourService> logger,
            ITourRepository tourRepository,
            IGuideRepository guideRepository,
            IAnimalRepository animalRepository,
            IZooRepository zooRepository,
            ITransaction baseRepository)
        {
            _logger = logger;
            _tourRepository = tourRepository;
            _guideRepository = guideRepository;
            _animalRepository = animalRepository;
            _zooRepository = zooRepository;
            _baseRepository = baseRepository;
        }

        public async Task<ServiceResponse<List<Tour>>> GetAllTours()
        {
            ServiceResponse<List<Tour>> response = new ServiceResponse<List<Tour>>();
            var list = await _tourRepository.GetAllTours();
            if(list == null || list.Count==0) 
            {
                response.IsSuccess = false;
                response.UserInfo = "Finns ännu inga tours att visa, var god skapa en ny tour.";
                return response;
            }
            response.IsSuccess = true;
            response.Data = list;
            return response;
        }

        public async Task<ServiceResponse<List<ZooTour>>> GetCurrentDayZooTours(DateTime currentDate)
        {
            ServiceResponse<List<ZooTour>> response = new ServiceResponse<List<ZooTour>>();

            var list = await _tourRepository.GetZooToursByDate(currentDate);
            if (list == null || list.Count == 0)
            {
                response.IsSuccess = false;
                response.UserInfo = "Det finns inga turer den här dagen.";
                return response;
            }
            response.IsSuccess = true;
            response.Data = list;
            return response;
        }

        public async Task<ServiceResponse<List<Visitor>>> BookZooTour
                                                            (Guid zooTourId, 
                                                            int NrOfPersonsToBook,
                                                            List<string>? personNames)
        {
            ServiceResponse<List<Visitor>> response = new ServiceResponse<List<Visitor>>();
            var transaction = _baseRepository.BeginTransaction();

            try
            {
                var zootour = await _tourRepository.GetZooTourById(zooTourId);
                if (zootour == null)
                {
                    response.IsSuccess = false;
                    response.UserInfo = "Något är fel med turen, försök boka igen.";
                    return response;
                }
                // Check animal fatigue and implement the business logic for this
                if (!await CheckAnimalFatigue(
                                zootour.Tour.GuideId,
                                zootour.ZooDay,
                                zootour.DateOfTour))
                {
                    await transaction.RollbackAsync();
                    response.IsSuccess = false;
                    response.UserInfo = "Denna turen går tyvärr inte att boka, det är för många besök under samma dag till ett eller flera djur som ingår i turen.";
                    return response;
                }

                // Make sure there is no overbooking
                if ((zootour.NrOfParticipants + NrOfPersonsToBook) > 5)
                {
                    await transaction.RollbackAsync();
                    response.IsSuccess = false;
                    response.UserInfo = "För många personer, max 5 personer per bokad tur. Det är redan " + zootour.NrOfParticipants + " personer bokade.";
                    return response;
                }

                // Updates the nr of participants
                zootour.NrOfParticipants += NrOfPersonsToBook;
                if (!await _tourRepository.UpdateZooTour(zootour))
                {
                    await transaction.RollbackAsync();
                    response.IsSuccess = false;
                    response.UserInfo = "Fel i databas, försök igen senare.";
                    return response;
                }
                await transaction.CommitAsync();


                // Add tickets
                try
                {
                    var visitors = await HandleTickets(NrOfPersonsToBook, personNames, zootour.Tour, zootour.DateOfTour);
                    if (visitors == null)
                    {
                        response.IsSuccess = false;
                        response.UserInfo = "Fel vid biljettadministration, försök igen senare eller kontakta receptionen.";
                        return response;
                    }
                    await transaction.CommitAsync();
                    response.Data = visitors;
                }
                catch (DbUpdateException ex)
                {
                    response.IsSuccess = false;
                    response.UserInfo = "Fel vid biljettadministration, försök igen senare eller kontakta receptionen.";
                    return response;
                }
                
                // Happy path :)
                response.IsSuccess = true;
                return response;
            } 
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                response.IsSuccess = false;
                response.ErrorMessage = "An error occurred. Please try again later.";
                _logger.LogInformation(ex.Message);
                return response;
            }
        }

        private async Task<bool> CheckAnimalFatigue(Guid guideId, 
                                                    ZooDay zooday, 
                                                    DateTime tourDate)
        {
            var animalsIds = await _animalRepository.GetAnimalsByGuideId(guideId);

            foreach (var animalId in animalsIds)
            {
                int nrOfVisits = await _animalRepository.GetAnimalVisitsByDateAndAnimal(animalId, tourDate);
                if (nrOfVisits >= 2)
                {
                    return false;
                }
            }

            foreach (var animalId in animalsIds)
            {
                var animal = await _animalRepository.GetAnimalById(animalId);
                AnimalVisit av = new AnimalVisit(zooday, animal);
                if (!await _animalRepository.AddAnimalVisit(av))
                {
                    return false;
                }
            }
            return true;
        }

        private async Task<List<Visitor>> HandleTickets(
                                        int NrOfPersons,
                                        List<string>? personNames,
                                        Tour tour, 
                                        DateTime visitDate)
        {
            List<Visitor> visitors = new List<Visitor>();
            for (int i = 0; i < NrOfPersons; i++)
            {
                Visitor visitor = new Visitor();
                if (personNames[i] != null) visitor.Alias = personNames[i];
                if (!await _zooRepository.AddVisitor(visitor))
                {
                    throw new DbUpdateException();
                }
                visitors.Add(visitor);
            }
            foreach (var visitor in visitors)
            {
                TourParticipant tp = new TourParticipant(tour, visitor, visitDate);
                if (!await _zooRepository.AddTourParticipant(tp))
                {
                    throw new DbUpdateException();
                }  
            }

            return visitors;
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
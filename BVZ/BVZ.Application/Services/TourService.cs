using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Domain.Models.Zoo;
using BVZ.BVZ.Domain.Models.Zoo.Animals;
using BVZ.Models.Admin;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace BVZ.BVZ.Application.Services
{
    public class TourService
    {
        private readonly ILogger<TourService> _logger;
        private readonly ITourRepository _tourRepository;
        private readonly IAnimalRepository _animalRepository;
        private readonly IZooRepository _zooRepository;
        private readonly ITransaction _baseRepository;

        public object Object { get; }

        public TourService(
            ILogger<TourService> logger,
            ITourRepository tourRepository,
            IAnimalRepository animalRepository,
            IZooRepository zooRepository,
            ITransaction baseRepository)
        {
            _logger = logger;
            _tourRepository = tourRepository;
            _animalRepository = animalRepository;
            _zooRepository = zooRepository;
            _baseRepository = baseRepository;
        }

        public async Task<ServiceResponse<List<Tour>>> GetAllTours()
        {
            ServiceResponse<List<Tour>> response = new ServiceResponse<List<Tour>>();
            var list = await _tourRepository.GetAllTours();
            if (list == null || list.Count==0)
            {
                response.IsSuccess = false;
                response.UserInfo = "Finns ännu inga tours att visa, var god skapa en ny tour.";
                return response;
            }
            response.IsSuccess = true;
            response.Data = list;
            return response;
        }

        public async Task<ServiceResponse<string>> SoftDeleteTour(Guid tourId)
        {
            ServiceResponse<string> result = new ServiceResponse<string>();

            var tour = await _tourRepository.GetTourById(tourId);
            if (tour == null)
            {
                result.IsSuccess = false;
                result.ErrorMessage= "Ingen tour med valt id hittades";
                return result;
            }

            tour.IsArchived = true;

            if(!await _tourRepository.UpdateTour(tour))
            {
                result.IsSuccess = false;
                result.ErrorMessage = "Gick inte att ta bort den valda touren";
                return result;
            }

            result.IsSuccess = true;
            result.Data = $"{tour.TourName} är borttagen";
            return result;
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

        public async Task<ServiceResponse<List<Tour>>> GetAvailableTours()
        {
            ServiceResponse<List<Tour>> response = new ServiceResponse<List<Tour>>();

            var today = DateTime.Now;
            var availableTours = await _tourRepository.GetToursAvailableToday(today);
            if (availableTours == null || availableTours.Count == 0)
            {
                response.IsSuccess = false;
                response.UserInfo = "Det finns inga fler turer den här dagen att schemalägga.";
                return response;
            }
            response.IsSuccess = true;
            response.Data = availableTours;
            return response;
        }

        public async Task<ServiceResponse<int>> GetSchedeuleTourOptions(Guid Id)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();

            try
            {
                // Will check the object returned for morning or afternoon-tour. Null signalize both is available.
                // Controller will need to handle 1,2 and 3.
                int codeForBooking = 0;
                var today = DateTime.Now;
                var optionsToSchedeule = await _tourRepository.GetBookingOptionsForTour(Id, today);

               
                if (optionsToSchedeule == null) 
                { 
                    codeForBooking = 3;
                    response.IsSuccess = true;
                    response.Data = codeForBooking;
                    return response;
                }

                if (optionsToSchedeule.IsMorningTour) 
                { 
                    codeForBooking = 1; 
                }

                if (!optionsToSchedeule.IsMorningTour) 
                { 
                    codeForBooking = 2; 
                }

                response.IsSuccess = true;
                response.Data = codeForBooking;
                return response;
            }
           
             catch (Exception ex)
            {
                response.IsSuccess = false;
                response.UserInfo = "Det finns inga fler turer den här dagen att schemalägga.";
                return response;
            }
        }

        public async Task<ServiceResponse<string>> SchedeuleDailyTours(Guid tourId, string? morning, string? afternoon)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();

            var today = DateTime.Now;

            var zooDay = await _zooRepository.GetZooDayByDate(today);
            if (zooDay == null)
            {
                response.IsSuccess = false;
                response.UserInfo = "Det är något fel med parkens öppningstider. Kontakta reception.";
                return response;
            }
            var tour = await _tourRepository.GetTourById(tourId);
            if (tour == null)
            {
                response.IsSuccess = false;
                response.UserInfo = "Rätt tur går inte att knyta till dagens datum. Kontakta administratör.";
                return response;
            }
            

            if(morning != null)
            {
                ZooTour morningTour = new ZooTour(tour, zooDay, true, today);

                if (!await _tourRepository.AddZooTour(morningTour))
                {
                    response.IsSuccess = false;
                    response.UserInfo = "Kunde inte schemalägga dagens tur. Något är fel med databas. Kontakta administratör.";
                    return response;
                }
            }

            if (afternoon != null)
            {
                ZooTour afternoonTour = new ZooTour(tour, zooDay, false, today);

                if (!await _tourRepository.AddZooTour(afternoonTour))
                {
                    response.IsSuccess = false;
                    response.UserInfo = "Kunde inte schemalägga dagens tur. Något är fel med databas. Kontakta administratör.";
                    return response;
                }
            }

            response.IsSuccess = true;
            response.Data = "Turen eller turerna är framgångsrikt schemalagda";
            return response;
        }



        //ANDREAS TANKAR OCH KNASIGA FUNDERINGAR!!
        //Vill skapa en tour så den kopplas ihop med vald dag (ZooDay) och ZooTours i formuläret.
        //Är ju mer än en Tour som skapas... är det rätt att bara returnera en Tour i responset?
        //Kollar inte om Guiden är dubbelbokad... t.ex dubbla eftermiddag/förmiddagspass på samma dag
        //Kollar inte Guidens kompetens... hur nu det skulle gå till då man inte väljer vilka djur som ska vara på turen.
        //Hur fan kollar man djuret... behövs ens det i detta läget?

        public async Task<ServiceResponse<Tour>> CreateNewTour(DisplayAdminAnimalsViewModel TourVm)
        {
            ServiceResponse<Tour> response = new ServiceResponse<Tour>();

            var tour = new Tour()
            {
                TourName = TourVm.TourName,
                Description = TourVm.TourDescription,
                GuideId = TourVm.SelectdGuideId
            };


            if (!await _tourRepository.CreateTour(tour))
            {
                response.IsSuccess = false;
                response.UserInfo = "Fel vid skapadet av ny Tour, försök igen senare eller kontakta supporten.";
                return response;
            }
            response.IsSuccess = true;
            response.Data = tour;
            response.UserInfo = $"Ny Tour med id {tour.Id} skapades";
            return response;

        }


        //ScheduleZooTour - Skapar en ZooTour med dagens ZooDay
        //kolla så Tour som kopplas inte redan krockar med en ZooTour för den aktuella dagen
        //en på förmiddag en på eftermiddag.
        //Kolla så varje guiden är ledig?
        public async Task<ServiceResponse<ZooTour>> SheduleZooTour()
        {
            ServiceResponse<ZooTour> response = new ServiceResponse<ZooTour>();
            return response;
        }


        //public async Task<ServiceResponse<Tour>> CreateNewTour(AdminCreateTourViewModel TourVm)
        //{
        //    ServiceResponse<Tour> response = new ServiceResponse<Tour>();
        //    var transaction = _baseRepository.BeginTransaction();

        //    //I would prefer not to create a new Tour like this... is it even possible?
        //    try
        //    {
        //        var tour = new Tour();
        //        tour.TourName = TourVm.TourName;
        //        tour.Description = TourVm.Description;
        //        tour.GuideId = TourVm.GuideId;

        //        //var newTour = await _tourRepository.CreateTour(tour);
        //        if(!await _tourRepository.CreateTour(tour))
        //        {
        //            await transaction.RollbackAsync();
        //            response.IsSuccess = false;
        //            response.UserInfo = "Fel vid skapadet av ny Tour, försök igen senare eller kontakta supporten.";
        //            return response;
        //        }


        //        //We need to have a ZooDay to associate it, should we just link it to TodayDate
        //        //var todayZooDayId = _zooRepository.GetZooDayIdByTodaysDate(DateTime.Now);

        //        //Lyft ur detta

        //        //Link them together
        //        var zooTour = new ZooTour();
        //        zooTour.TourID = tour.Id;
        //        zooTour.ZooDayId = await _zooRepository.GetZooDayIdByTodaysDate(DateTime.Now.Date);

        //        //if(zooTour.ZooDayId == null)
        //        //{
        //        //    await transaction.RollbackAsync();
        //        //    response.IsSuccess = false;
        //        //    response.UserInfo = "Ingen dag med matchande ID funnet, ";
        //        //    return response;
        //        //}

        //        zooTour.DateOfTour = TourVm.DateOfTour;
        //        zooTour.IsMorningTour = TourVm.IsMorningTour;

        //        //Add a new ZooTour
        //        if(!await _tourRepository.AddZooTour(zooTour))
        //        {
        //            await transaction.RollbackAsync();
        //            response.IsSuccess = false;
        //            response.UserInfo = "Fel vid skapande av ZooTour, försök igen senare eller kontakta supporten.";
        //            return response;
        //        };

        //        //Return... Is it possible to make a better model for the VM to display, like a more complete DTO?
        //        await transaction.CommitAsync();
        //        response.Data = tour;
        //        response.IsSuccess = true;
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        await transaction.RollbackAsync();
        //        response.IsSuccess = false;
        //        response.ErrorMessage = "Yay! Något gick helt fel! Försök igen senare eller kontakta supporten.";
        //        _logger.LogInformation(ex.Message);
        //        return response;
        //    }
        //}

        public async Task<ServiceResponse<List<Visitor>>> BookZooTour
                                                (Guid zooTourId,
                                                int NrOfPersonsToBook,
                                                List<string> bookers,
                                                bool hasTickets)
        {
            ServiceResponse<List<Visitor>> response = new ServiceResponse<List<Visitor>>();
            // Allow us to make rollbakcs if something fails somewhere along the chain of the entire method
            var transaction = _baseRepository.BeginTransaction();

            try // Wraps entire method, allowing for proper commits or rollbacks
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
                    if (transaction != null)
                    {
                        await transaction.RollbackAsync();
                    }
                    response.IsSuccess = false;
                    response.UserInfo = "För många personer, max 5 personer per bokad tur. Det är redan " + zootour.NrOfParticipants + " personer bokade.";
                    return response;
                }

                // Updates the nr of participants
                zootour.NrOfParticipants += NrOfPersonsToBook;
                if (!await _tourRepository.UpdateZooTour(zootour))
                {
                    if (transaction != null)
                    {
                        await transaction.RollbackAsync();
                    }
                    response.IsSuccess = false;
                    response.UserInfo = "Fel i databas, försök igen senare.";
                    return response;
                }

                // Method handling tickets or lack of ticket
                try
                {
                    var visitors = await HandleTickets(
                                        NrOfPersonsToBook,
                                        bookers,
                                        zootour.Tour,
                                        zootour.DateOfTour,
                                        zootour.IsMorningTour,
                                        hasTickets);
                    if (visitors == null)
                    {
                        if (transaction != null)
                        {
                            await transaction.RollbackAsync();
                        }
                        response.IsSuccess = false;
                        response.UserInfo = "Fel vid biljettadministration, försök igen senare eller kontakta receptionen.";
                        return response;
                    }
                    response.Data = visitors;
                }
                catch (Exception ex)
                {
                    if (ex is DbUpdateException || ex is InvalidDataException || ex is FormatException)
                    {
                        await transaction.RollbackAsync();
                        response.IsSuccess = false;
                        response.UserInfo = "Fel vid biljettadministration, försök igen senare eller kontakta receptionen.";
                        _logger.LogInformation(ex.Message);
                        return response;
                    }
                }

                // Happy path :)
                await transaction.CommitAsync();
                response.IsSuccess = true;
                return response;
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    await transaction.RollbackAsync();
                }
                response.IsSuccess = false;
                response.ErrorMessage = "An error occurred. Please try again later.";
                _logger.LogInformation(ex.Message);
                return response;
            }
        }

        public async Task<bool> CheckAnimalFatigue(Guid guideId,
                                                    ZooDay zooday,
                                                    DateTime tourDate)
        {
            var animalsIds = await _animalRepository.GetAnimalsByGuideId(guideId);

            // Make sure no specific specie has received more than two visit on the same day.
            foreach (var animalId in animalsIds)
            {
                int nrOfVisits = await _animalRepository.GetAnimalVisitsByDateAndAnimal(animalId, tourDate);
                if (nrOfVisits >= 2)
                {
                    return false;
                }
            }
            // Register a visit for each or the tours species that is visited.
            foreach (var animalId in animalsIds)
            {
                var animal = await _animalRepository.GetAnimalById(animalId);
                AnimalVisit av = new AnimalVisit(animal);
                if (!await _animalRepository.AddAnimalVisit(av))
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<List<Visitor>> HandleTickets(
                                            int NrOfPersons,
                                            List<string> bookers,
                                            Tour tour,
                                            DateTime visitDate,
                                            bool isMorningTour,
                                            bool hasTickets)
        {

            List<Visitor> visitors = new List<Visitor>();

            // Handles the case if bookers of tour dont have a zoo-ticket
            if (!hasTickets)
            {
                for (int i = 0; i < NrOfPersons; i++)
                {
                    Visitor visitor = new Visitor();
                    if (bookers[i] != null) visitor.Alias = bookers[i];
                    else throw new InvalidDataException();
                    if (!await _zooRepository.AddVisitor(visitor))
                    {
                        throw new DbUpdateException();
                    }
                    visitors.Add(visitor);
                }
            }

            // Handles the case where visitor claim to have a ticket and validate if the claim is legit
            else
            {
                var dailyVisitors = await _zooRepository.GetDailyZooVisitors(DateTime.Now);
                if (dailyVisitors == null) throw new InvalidDataException("No visitors for this date.");

                if (NrOfPersons != bookers.Count) throw new InvalidDataException("Nr of persons does not match nr of tickets provided.");

                foreach (var booker in bookers)
                {
                    Guid ticketId = Guid.Parse(booker);

                    var visitor = dailyVisitors.Where(visitor => visitor.Id == ticketId).SingleOrDefault();

                    if (visitor != null)
                    {
                        visitors.Add(visitor);
                    }
                    else throw new InvalidDataException("Ticket can not be found in database.");
                }
            }

            // Register each booker as a participant of the particular tour-type.
            foreach (var visitor in visitors)
            {
                TourParticipant tp = new TourParticipant(tour, visitor, visitDate, isMorningTour);
                if (!await _zooRepository.AddTourParticipant(tp))
                {
                    throw new DbUpdateException("Can't create tourparticipants.");
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
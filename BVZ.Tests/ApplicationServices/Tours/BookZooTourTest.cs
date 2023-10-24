using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Application.Services;
using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Domain.Models.Zoo;
using BVZ.BVZ.Domain.Models.Zoo.Animals;
using Microsoft.Extensions.Logging;
using Moq;

namespace BVZ.Tests.ApplicationServices.Tours
{
    public class BookZooTourTest
    {
        private Mock<ILogger<TourService>> loggerMock;
        private Mock<ITourRepository> tourRepositoryMock;
        private Mock<IAnimalRepository> animalRepositoryMock;
        private Mock<IZooRepository> zooRepositoryMock;
        private Mock<ITransaction> transactionMock;

        private ITransaction transaction;
        private Guid ztIdMock;
        private int NrOfPersonsMock;
        private List<string> bookers;
        private bool hasTickets;
        private ZooTour zootour;
        private List<Visitor> visitorList;
        private List<Guid> animalIdList;
        private Ozelot animalMock;
        private int nrOfVisitMock;

        public BookZooTourTest()
        {
            loggerMock = new Mock<ILogger<TourService>>();
            tourRepositoryMock = new Mock<ITourRepository>();
            animalRepositoryMock = new Mock<IAnimalRepository>();
            zooRepositoryMock = new Mock<IZooRepository>();
            transactionMock = new Mock<ITransaction>();

            transaction = transactionMock.Object;
            ztIdMock = Guid.NewGuid();
            NrOfPersonsMock = 3;
            nrOfVisitMock = 0;
            hasTickets = true;

            bookers = new List<string>
            {
                "123e4967-e89b-22da-a456-426655440000",
                "123e4567-e80b-1223-a456-426655440000",
                "123e4567-e89b-12dc-a456-426650990000"
            };

            zootour = new ZooTour
            {
                Id = Guid.NewGuid(),
                ZooDay = new ZooDay
                {
                    Id = Guid.NewGuid(),
                    TodaysDate = DateTime.Now,

                },
                Tour = new Tour
                {
                    Id = Guid.NewGuid(),
                    TourName = "Pomperipossas tur",
                    Description = "En tur i LaLa-land",
                    GuideId = Guid.NewGuid(),
                },
                IsMorningTour = true,
                NrOfParticipants = 0,
            };

            visitorList = new List<Visitor>
            {
                new Visitor
                {
                    Id = Guid.Parse("123e4967-e89b-22da-a456-426655440000"),
                    Alias = "Eva",
                    TicketDate = DateTime.Now,
                    TourParticipants = new List<TourParticipant>
                    {
                        new TourParticipant
                        {
                            Id = Guid.NewGuid(),
                            VisitorId = Guid.NewGuid(),
                            VisitDate = DateTime.Now,
                            TourID = Guid.NewGuid(),
                            TourSession = BVZ.Domain.Models.Visitors.ValueTypes.TourSession.Morning
                        }
                    }
                },
                new Visitor
                {
                    Id = Guid.Parse("123e4567-e80b-1223-a456-426655440000"),
                    Alias = "Gunde",
                    TicketDate = DateTime.Now,
                     TourParticipants = new List<TourParticipant>
                    {
                        new TourParticipant
                        {
                            Id = Guid.NewGuid(),
                            VisitorId = Guid.NewGuid(),
                            VisitDate = DateTime.Now,
                            TourID = Guid.NewGuid(),
                            TourSession = BVZ.Domain.Models.Visitors.ValueTypes.TourSession.Morning
                        }
                    }
                },

                 new Visitor
                {
                    Id = Guid.Parse("123e4567-e89b-12dc-a456-426650990000"),
                    Alias = "Harald",
                    TicketDate = DateTime.Now,
                     TourParticipants = new List<TourParticipant>
                    {
                        new TourParticipant
                        {
                            Id = Guid.NewGuid(),
                            VisitorId = Guid.NewGuid(),
                            VisitDate = DateTime.Now,
                            TourID = Guid.NewGuid(),
                            TourSession = BVZ.Domain.Models.Visitors.ValueTypes.TourSession.Morning
                        }
                    }
                },
            };

            animalIdList = new List<Guid>
            {
                Guid.NewGuid(),
                Guid.NewGuid(),
            };

            animalMock = new Ozelot
            {
                Id = Guid.NewGuid(),
                AnimalName = "Harry",
                AnimalType = "Ozelot",
                Specie = Specie.Mammal,
                DailyVisits = 0,
                AnimalVisits = new List<AnimalVisit>
                    {
                        new AnimalVisit
                        {
                            Id = Guid.NewGuid(),
                            AnimalId = Guid.NewGuid(),
                            VisitDate = DateTime.Now,
                        }
                    }
            };
        }


        [Fact]
        public async Task BookZooTour_HasTickets_Success_ReturnsValidResponse()
        {
            hasTickets = true;

            // Main method
            tourRepositoryMock.Setup(repo => repo.GetZooTourById(ztIdMock)).ReturnsAsync(zootour);
            tourRepositoryMock.Setup(repo => repo.UpdateZooTour(zootour)).ReturnsAsync(true);

            //Commits and rollbacks
            transactionMock.Setup(repo => repo.BeginTransaction()).Returns(transaction);
            transactionMock.Setup(repo => repo.CommitAsync()).Returns(Task.CompletedTask);
            transactionMock.Setup(repo => repo.RollbackAsync()).Returns(Task.CompletedTask);

            // Helper-method CheckAnimalFatigue
            animalRepositoryMock.Setup(repo => repo.GetAnimalsByGuideId(zootour.Tour.GuideId)).ReturnsAsync(animalIdList);
            animalRepositoryMock.Setup(repo => repo.GetAnimalVisitsByDateAndAnimal(animalIdList[0], zootour.DateOfTour)).ReturnsAsync(nrOfVisitMock);
            animalRepositoryMock.Setup(repo => repo.GetAnimalById(animalIdList[0])).ReturnsAsync(animalMock);
            animalRepositoryMock.Setup(repo => repo.AddAnimalVisit(It.IsAny<AnimalVisit>())).ReturnsAsync(true);

            // Helper-method HandleTickets
            zooRepositoryMock.Setup(repo => repo.AddVisitor(visitorList[0])).ReturnsAsync(true);
            zooRepositoryMock.Setup(repo => repo.GetDailyZooVisitors(It.IsAny<DateTime>())).ReturnsAsync(visitorList);
            zooRepositoryMock.Setup(repo => repo.AddTourParticipant(It.IsAny<TourParticipant>())).ReturnsAsync(true);

            var tourService = new TourService(
                loggerMock.Object,
                tourRepositoryMock.Object,
                animalRepositoryMock.Object,
                zooRepositoryMock.Object,
                transactionMock.Object);

            // Act
            var result = await tourService.BookZooTour(
                ztIdMock,
                NrOfPersonsMock,
                bookers,
                hasTickets);

            var animalFatigueResult = await tourService.CheckAnimalFatigue(
                zootour.Tour.GuideId,
                zootour.ZooDay,
                zootour.DateOfTour);

            var handleTicketsResult = await tourService.HandleTickets(
                NrOfPersonsMock,
                bookers,
                zootour.Tour,
                zootour.DateOfTour,
                true,
                hasTickets);


            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(visitorList, result.Data);
            Assert.Null(result.UserInfo);
        }


        [Fact]
        public async Task BookZooTour_HasNoTickets_Success_ReturnsValidResponse()
        {
            hasTickets = false;
            bookers = new List<string>
            {
                "Eva",
                "Gunde",
                "Harald"
            };

            List<Visitor> newVisitorsList = new List<Visitor>();

            // Main method
            tourRepositoryMock.Setup(repo => repo.GetZooTourById(ztIdMock)).ReturnsAsync(zootour);
            tourRepositoryMock.Setup(repo => repo.UpdateZooTour(zootour)).ReturnsAsync(true);

            //Commits and rollbacks
            transactionMock.Setup(repo => repo.BeginTransaction()).Returns(transaction);
            transactionMock.Setup(repo => repo.CommitAsync()).Returns(Task.CompletedTask);
            transactionMock.Setup(repo => repo.RollbackAsync()).Returns(Task.CompletedTask);

            // Helper-method CheckAnimalFatigue
            animalRepositoryMock.Setup(repo => repo.GetAnimalsByGuideId(zootour.Tour.GuideId)).ReturnsAsync(animalIdList);
            animalRepositoryMock.Setup(repo => repo.GetAnimalVisitsByDateAndAnimal(animalIdList[0], zootour.DateOfTour)).ReturnsAsync(nrOfVisitMock);
            animalRepositoryMock.Setup(repo => repo.GetAnimalById(animalIdList[0])).ReturnsAsync(animalMock);
            animalRepositoryMock.Setup(repo => repo.AddAnimalVisit(It.IsAny<AnimalVisit>())).ReturnsAsync(true);

            // Helper-method HandleTickets
            zooRepositoryMock.Setup(repo => repo.AddVisitor(It.IsAny<Visitor>())).ReturnsAsync(true);
            zooRepositoryMock.Setup(repo => repo.AddTourParticipant(It.IsAny<TourParticipant>())).ReturnsAsync(true);
  

                var tourService = new TourService(
                    loggerMock.Object,
                    tourRepositoryMock.Object,
                    animalRepositoryMock.Object,
                    zooRepositoryMock.Object,
                    transactionMock.Object);

                // Act
                var result = await tourService.BookZooTour(
                    ztIdMock,
                    NrOfPersonsMock,
                    bookers,
                    hasTickets);

                var animalFatigueResult = await tourService.CheckAnimalFatigue(
                    zootour.Tour.GuideId,
                    zootour.ZooDay,
                    zootour.DateOfTour);

                var handleTicketsResult = await tourService.HandleTickets(
                    NrOfPersonsMock,
                    bookers,
                    zootour.Tour,
                    zootour.DateOfTour,
                    true,
                    hasTickets);


                // Assert
                Assert.True(result.IsSuccess);
                Assert.NotNull(handleTicketsResult);
                Assert.Null(result.UserInfo);
            }
        }

}

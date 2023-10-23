using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Application.Services;
using BVZ.BVZ.Domain.Models.Visitors;
using Microsoft.Extensions.Logging;
using Moq;

namespace BVZ.Tests.ApplicationServices.Tours
{
    public class BookZooTourTest
    {

        [Fact]
        public async Task BookZooTour_HasTickets_Success_ReturnsValidResponse()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<TourService>>();
            var tourRepositoryMock = new Mock<ITourRepository>();
            var animalRepositoryMock = new Mock<IAnimalRepository>();
            var zooRepositoryMock = new Mock<IZooRepository>();
            var transactionMock = new Mock<ITransaction>();

            Guid ztIdMock = Guid.NewGuid();
            int NrOfPersonsMock = 4;
            List<string> ticketNrsMock = new List<string>
            {
                "123e4967-e89b-22da-a456-426655440000",
                "123e4567-e80b-1223-a456-426655440000",
                "123e4567-e89b-12dc-a456-426650990000"
            };
            bool hasTickets = true;

            var zootour = new ZooTour
            {
                Id = Guid.Empty,
                ZooDayId = Guid.Empty,
                TourID = Guid.Empty,
                IsMorningTour = true,
                NrOfParticipants = 0,
            };

            var visitorList = new List<Visitor>
            {
                new Visitor
                {
                    Id = Guid.Empty,
                    Alias = "Eva",
                    TicketDate = DateTime.Now
                },
                new Visitor
                {
                    Id = Guid.Empty,
                    Alias = "Eva",
                    TicketDate = DateTime.Now
                },
            };


            //tourRepositoryMock.Setup(repo => repo.GetZooTourById(ztIdMock).ReturnsAsync(zootour));
            //tourRepositoryMock.Setup(repo => repo.GetZooTourById(ztIdMock).ReturnsAsync(zootour));

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
                ticketNrsMock,
                hasTickets);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(visitorList, result.Data);
            Assert.Null(result.ErrorMessage);
        }


        [Fact]
        public async Task GetAllTours_ListIsNull_ReturnsErrorResponse()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<TourService>>();
            var tourRepositoryMock = new Mock<ITourRepository>();
            var animalRepositoryMock = new Mock<IAnimalRepository>();
            var zooRepositoryMock = new Mock<IZooRepository>();
            var transactionMock = new Mock<ITransaction>();


            DateTime day = DateTime.Now;
            List<ZooTour> emptyList = new List<ZooTour>();

            tourRepositoryMock.Setup(repo => repo.GetZooToursByDate(day)).ReturnsAsync(emptyList);

            var tourService = new TourService(
                loggerMock.Object,
                tourRepositoryMock.Object,
                animalRepositoryMock.Object,
                zooRepositoryMock.Object,
                transactionMock.Object
            );

            // Act
            var result = await tourService.GetCurrentDayZooTours(day);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Null(result.Data);
            Assert.Contains("inga turer", result.UserInfo);
        }
    }
}

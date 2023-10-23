using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Application.Services;
using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Domain.Models.Zoo;
using Microsoft.Extensions.Logging;
using Moq;

namespace BVZ.Tests.ApplicationServices.Tours
{
    public class GetCurrentDayZooToursTest
    {
        // Other test methods...

        [Fact]
        public async Task GetCurrentDayZooTours_Success_ReturnsValidResponse()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<TourService>>();
            var tourRepositoryMock = new Mock<ITourRepository>();
            var animalRepositoryMock = new Mock<IAnimalRepository>();
            var zooRepositoryMock = new Mock<IZooRepository>();
            var transactionMock = new Mock<ITransaction>();

            DateTime day = DateTime.Now;

            var toursList = new List<ZooTour>
            {
                new ZooTour
                {
                    Id = Guid.Empty,
                    ZooDayId = Guid.Empty,
                    TourID = Guid.Empty,
                    DateOfTour = day,
                    IsMorningTour= true,
                    NrOfParticipants = 0,
                },
                 new ZooTour
                {
                    Id = Guid.Empty,
                    ZooDayId = Guid.Empty,
                    TourID = Guid.Empty,
                    DateOfTour = day,
                    IsMorningTour= false,
                    NrOfParticipants = 2,
                },
            };


            tourRepositoryMock.Setup(repo => repo.GetZooToursByDate(day)).ReturnsAsync(toursList);

            var tourService = new TourService(
                loggerMock.Object,
                tourRepositoryMock.Object,
                animalRepositoryMock.Object,
                zooRepositoryMock.Object,
                transactionMock.Object);

            // Act
            var result = await tourService.GetCurrentDayZooTours(day);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(toursList, result.Data);
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

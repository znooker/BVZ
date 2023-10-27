using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Application.Services;
using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Land;
using Microsoft.Extensions.Logging;
using Moq;
using System.Drawing.Text;

namespace BVZ.Tests.ApplicationServices.Tours
{
    public class GetAvailableToursTest
    {
        private Mock<ILogger<TourService>> loggerMock;
        private Mock<ITourRepository> tourRepositoryMock;
        private Mock<IAnimalRepository> animalRepositoryMock;
        private Mock<IZooRepository> zooRepositoryMock;
        private Mock<ITransaction> transactionMock;

        private List<Tour> emptyList;
        private List<Tour> nullList;
        private List<Tour> toursList;
        private DateTime mockDate;

        private TourService tourService;

        public GetAvailableToursTest()
        {
            loggerMock = new Mock<ILogger<TourService>>();
            tourRepositoryMock = new Mock<ITourRepository>();
            animalRepositoryMock = new Mock<IAnimalRepository>();
            zooRepositoryMock = new Mock<IZooRepository>();
            transactionMock = new Mock<ITransaction>();
          
            emptyList = new List<Tour>();
            nullList = null;

            toursList = new List<Tour>
            {
                new Tour
                {
                    Id = Guid.Empty,
                    TourName = "Pomperipossas tur",
                    Description = "En tur i LaLa-land",
                    GuideId = Guid.Empty,
                },
                 new Tour
                {
                    Id = Guid.Empty,
                    TourName = "´Katlas tur",
                    Description = "En tur i drakarnas land",
                    GuideId = Guid.Empty,
                },
            };
            mockDate = DateTime.Now;

            tourService = new TourService(
               loggerMock.Object,
               tourRepositoryMock.Object,
               animalRepositoryMock.Object,
               zooRepositoryMock.Object,
               transactionMock.Object);
        }

        [Fact]
        public async Task GetAvailableToursTest_Success_ReturnsValidResponse()
        {
            tourRepositoryMock.Setup(repo => repo.GetToursAvailableToday(It.IsAny<DateTime>())).ReturnsAsync(toursList);

            var result = await tourService.GetAvailableTours();

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(toursList, result.Data);
            Assert.Null(result.ErrorMessage);
        }

        [Fact]
        public async Task GetAvailableToursTest_Zero_ReturnsErrorResponse()
        {
            tourRepositoryMock.Setup(repo => repo.GetToursAvailableToday(It.IsAny<DateTime>())).ReturnsAsync(emptyList);

            var result = await tourService.GetAvailableTours();

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Null(result.Data);
            Assert.Contains("inga", result.UserInfo);
        }

        [Fact]
        public async Task GetAvailableToursTest_Null_ReturnsErrorResponse()
        {
            tourRepositoryMock.Setup(repo => repo.GetToursAvailableToday(It.IsAny<DateTime>())).ReturnsAsync(nullList);

            var result = await tourService.GetAvailableTours();

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Null(result.Data);
            Assert.Contains("inga", result.UserInfo);
        }
    }
}


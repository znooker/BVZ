using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Application.Services;
using BVZ.BVZ.Domain.Models.Visitors;
using Microsoft.Extensions.Logging;
using Moq;

namespace BVZ.Tests.ApplicationServices.Tours
{
    public class GetSchedeuleTourOptionsTest
    {
        private Mock<ILogger<TourService>> loggerMock;
        private Mock<ITourRepository> tourRepositoryMock;
        private Mock<IAnimalRepository> animalRepositoryMock;
        private Mock<IZooRepository> zooRepositoryMock;
        private Mock<ITransaction> transactionMock;

        private Guid idMock;
        private ZooTour zootourMock;

        private TourService tourService;

        public GetSchedeuleTourOptionsTest()
        {
            loggerMock = new Mock<ILogger<TourService>>();
            tourRepositoryMock = new Mock<ITourRepository>();
            animalRepositoryMock = new Mock<IAnimalRepository>();
            zooRepositoryMock = new Mock<IZooRepository>();
            transactionMock = new Mock<ITransaction>();

            zootourMock = new ZooTour();
            idMock = Guid.NewGuid();

            tourService = new TourService(
               loggerMock.Object,
               tourRepositoryMock.Object,
               animalRepositoryMock.Object,
               zooRepositoryMock.Object,
               transactionMock.Object);
        }

        [Fact]
        public async Task GetSchedeuleTourOptions_MorningIsTrue_Success_ReturnsValidResponse()
        {
            zootourMock.IsMorningTour = true;

            tourRepositoryMock.Setup(repo => repo.GetBookingOptionsForTour(idMock, It.IsAny<DateTime>()))
                .ReturnsAsync(zootourMock);

            var result = await tourService.GetSchedeuleTourOptions(idMock);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.Data);
            Assert.Null(result.ErrorMessage);
        }

        [Fact]
        public async Task GetSchedeuleTourOptions_MorningIsFalse_Success_ReturnsValidResponse()
        {
            zootourMock.IsMorningTour = false;

            tourRepositoryMock.Setup(repo => repo.GetBookingOptionsForTour(idMock, It.IsAny<DateTime>()))
                .ReturnsAsync(zootourMock);

            var result = await tourService.GetSchedeuleTourOptions(idMock);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(1, result.Data);
            Assert.Null(result.ErrorMessage);
        }

        [Fact]
        public async Task GetSchedeuleTourOptions_NullResponse_Success_ReturnsValidResponse()
        {
            zootourMock = null;

            tourRepositoryMock.Setup(repo => repo.GetBookingOptionsForTour(idMock, It.IsAny<DateTime>()))
                .ReturnsAsync(zootourMock);

            var result = await tourService.GetSchedeuleTourOptions(idMock);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(3, result.Data);
            Assert.Null(result.ErrorMessage);
        }

        [Fact]
        public async Task GetSchedeuleTourOptions_Exception_ReturnsErrorResponse()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            tourRepositoryMock.Setup(repo => repo.GetBookingOptionsForTour(id, It.IsAny<DateTime>()))
                .ThrowsAsync(new Exception("Simulated exception"));

            // Act
            var result = await tourService.GetSchedeuleTourOptions(id);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Det finns inga fler turer den här dagen att schemalägga.", result.UserInfo);
        }
    }
}


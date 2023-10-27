using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Application.Services;
using BVZ.BVZ.Domain.Models.Visitors;
using Microsoft.Extensions.Logging;
using Moq;

namespace BVZ.Tests.ApplicationServices.Tours
{
    public class GetAllToursTest
    {
        private Mock<ILogger<TourService>> loggerMock;
        private Mock<ITourRepository> tourRepositoryMock;
        private Mock<IAnimalRepository> animalRepositoryMock;
        private Mock<IZooRepository> zooRepositoryMock;
        private Mock<ITransaction> transactionMock;

        private List<Tour> toursList;

        private TourService tourService;

        public GetAllToursTest()
        {
            loggerMock = new Mock<ILogger<TourService>>();
            tourRepositoryMock = new Mock<ITourRepository>();
            animalRepositoryMock = new Mock<IAnimalRepository>();
            zooRepositoryMock = new Mock<IZooRepository>();
            transactionMock = new Mock<ITransaction>();

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

            tourService = new TourService(
              loggerMock.Object,
              tourRepositoryMock.Object,
              animalRepositoryMock.Object,
              zooRepositoryMock.Object,
              transactionMock.Object);

        }


        [Fact]
        public async Task GetAllTours_Success_ReturnsValidResponse()
        {
            tourRepositoryMock.Setup(repo => repo.GetAllTours()).ReturnsAsync(toursList);

            var result = await tourService.GetAllTours();

            Assert.True(result.IsSuccess);
            Assert.Equal(toursList, result.Data);
            Assert.Null(result.ErrorMessage);
        }

        [Fact]
        public async Task GetAllTours_NoTours_ReturnsErrorResponse()
        {
            List<Tour> emptyList = new List<Tour>();

            tourRepositoryMock.Setup(repo => repo.GetAllTours()).ReturnsAsync(emptyList);

            var result = await tourService.GetAllTours();

            Assert.False(result.IsSuccess);
            Assert.Null(result.Data);
            Assert.Contains("inga tours", result.UserInfo);
        }
    }
}
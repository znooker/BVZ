using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Application.Services;
using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Domain.Models.Zoo.Guides;
using BVZ.BVZ.Infrastructure.Repositories;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVZ.Tests.ApplicationServices.Tours
{
    public class GetAllToursTest
    {
        [Fact]
        public async Task GetAllTours_Success_ReturnsValidResponse()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<TourService>>();
            var tourRepositoryMock = new Mock<ITourRepository>();
            var animalRepositoryMock = new Mock<IAnimalRepository>();
            var zooRepositoryMock = new Mock<IZooRepository>();
            var transactionMock = new Mock<ITransaction>();

            var toursList = new List<Tour>
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

            tourRepositoryMock.Setup(repo => repo.GetAllTours()).ReturnsAsync(toursList);

            var tourService = new TourService(
                loggerMock.Object,
                tourRepositoryMock.Object,
                animalRepositoryMock.Object,
                zooRepositoryMock.Object,
                transactionMock.Object);
            // Act
            var result = await tourService.GetAllTours();

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(toursList, result.Data);
            Assert.Null(result.ErrorMessage);
        }

        [Fact]
        public async Task GetAllTours_NoTours_ReturnsErrorResponse()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<TourService>>();
            var tourRepositoryMock = new Mock<ITourRepository>();
            var animalRepositoryMock = new Mock<IAnimalRepository>();
            var zooRepositoryMock = new Mock<IZooRepository>();
            var transactionMock = new Mock<ITransaction>();

            List<Tour> emptyList = new List<Tour>();

            tourRepositoryMock.Setup(repo => repo.GetAllTours()).ReturnsAsync(emptyList);

            var tourService = new TourService(
                loggerMock.Object,
                tourRepositoryMock.Object,
                animalRepositoryMock.Object,
                zooRepositoryMock.Object,
                transactionMock.Object
            );

            // Act
            var result = await tourService.GetAllTours();

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Null(result.Data);
            Assert.Contains("inga tours", result.UserInfo);
        }
    }
}
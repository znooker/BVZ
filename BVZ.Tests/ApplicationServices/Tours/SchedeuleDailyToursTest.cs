using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Application.Services;
using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Domain.Models.Zoo;
using BVZ.BVZ.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVZ.Tests.ApplicationServices.Tours
{
    public class SchedeuleDailyToursTest
    {
        private Mock<ILogger<TourService>> loggerMock;
        private Mock<ITourRepository> tourRepositoryMock;
        private Mock<IAnimalRepository> animalRepositoryMock;
        private Mock<IZooRepository> zooRepositoryMock;
        private Mock<ITransaction> transactionMock;

        private Guid TouridMock;
        private Tour tourMock;

        private ZooDay zoodayMock;

        private string morningMock;
        private string afternoonMock;

        private ZooTour zootourMock;

        private TourService tourService;

        public SchedeuleDailyToursTest()
        {
            loggerMock = new Mock<ILogger<TourService>>();
            tourRepositoryMock = new Mock<ITourRepository>();
            animalRepositoryMock = new Mock<IAnimalRepository>();
            zooRepositoryMock = new Mock<IZooRepository>();
            transactionMock = new Mock<ITransaction>();

            TouridMock = Guid.NewGuid();
            tourMock = new Tour();

            zoodayMock = new ZooDay();

            morningMock = null;
            afternoonMock = null;

            zootourMock = new ZooTour();

            ZooTour morningTour = new ZooTour(tourMock, zoodayMock, true, DateTime.Now);

            tourService = new TourService(
                loggerMock.Object,
                tourRepositoryMock.Object,
                animalRepositoryMock.Object,
                zooRepositoryMock.Object,
                transactionMock.Object);
        }

        [Fact]
        public async Task SchedeuleDailyToursTest_SchedeuleMorningTourIsSuccess_ReturnsValidResponse()
        {
            morningMock = "not null";

            zooRepositoryMock.Setup(repo => repo.GetZooDayByDate(It.IsAny<DateTime>()))
                .ReturnsAsync(zoodayMock);

            tourRepositoryMock.Setup(repo => repo.GetTourById(TouridMock))
                .ReturnsAsync(tourMock);

            tourRepositoryMock.Setup(repo => repo.AddZooTour(zootourMock))
                .ReturnsAsync(true);


            var result = await tourService.SchedeuleDailyTours(TouridMock, morningMock, afternoonMock);

            Assert.True(result.IsSuccess);
            Assert.Equal("Turen eller turerna är framgångsrikt schemalagda", result.Data);
            Assert.Null(result.ErrorMessage);
        }

        
    }
}


using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Application.Services;
using BVZ.BVZ.Domain.Models.Zoo.Guides;
using Microsoft.Extensions.Logging;
using Moq;

namespace BVZ.Tests.ApplicationServices.Guides
{
    public class GetAllGuidesTest
    {
        [Fact]
        public async Task GetAllGuides_Success_ReturnsValidResponse()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<GuideServices>>();
            var guideRepositoryMock = new Mock<IGuideRepository>();
            var transactionMock = new Mock<ITransaction>();

            var guideList = new List<Guide>
            {
                new Guide { Id = Guid.Parse("123e4567-e89b-12d3-a456-426655440000"), Name = "Pomperipossa", IsUnavailable = false },
                new Guide { Id = Guid.Parse("123e4567-e32b-12d3-a456-476665440000"), Name = "Katla", IsUnavailable = false }
            };

            guideRepositoryMock.Setup(repo => repo.GetAllGuides()).ReturnsAsync(guideList);

            var guideService = new GuideServices(
                loggerMock.Object,
                guideRepositoryMock.Object,
                transactionMock.Object
            );

            // Act
            var result = await guideService.GetAllGuides();

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(guideList, result.Data);
            Assert.Null(result.ErrorMessage);
        }

        [Fact]
        public async Task GetAllGuides_NoGuides_ReturnsErrorResponse()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<GuideServices>>();
            var guideRepositoryMock = new Mock<IGuideRepository>();
            var transactionMock = new Mock<ITransaction>();

            List<Guide> emptyList = new List<Guide>();

            guideRepositoryMock.Setup(repo => repo.GetAllGuides()).ReturnsAsync(emptyList);

            var guideService = new GuideServices(
                loggerMock.Object,
                guideRepositoryMock.Object,
                transactionMock.Object
            );

            // Act
            var result = await guideService.GetAllGuides();

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Null(result.Data);
            Assert.Equal("Kan inte hitta några guider", result.ErrorMessage);
        }
    }
}



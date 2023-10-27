using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Application.Services;
using BVZ.BVZ.Domain.Models.Zoo.Guides;
using Microsoft.Extensions.Logging;
using Moq;

namespace BVZ.Tests.ApplicationServices.Guides
{
    public class GetGuideByIdTest
    {
        private Mock<ILogger<GuideServices>> _loggerMock;
        private Mock<IGuideRepository> _guideRepositoryMock;
        private Mock<ITransaction> _baseRepositoryMock;
        private Mock<IAnimalCompetencesRepository> _animalCompetencesRepositoryMock;
        private Mock<IAnimalRepository> _animalRepositoryMock;

        private Guide _guide;
        private Guide _guide2;
        private GuideServices _guideService;

        public GetGuideByIdTest()
        {
            _loggerMock= new Mock<ILogger<GuideServices>>();
            _guideRepositoryMock = new Mock<IGuideRepository>();
            _baseRepositoryMock = new Mock<ITransaction>();
            _animalCompetencesRepositoryMock = new Mock<IAnimalCompetencesRepository>();
            _animalRepositoryMock = new Mock<IAnimalRepository>();

            _guide = new Guide { Id = Guid.Parse("123e4567-e89b-12d3-a456-426655440000"), Name = "Terminator", IsUnavailable = false };
            _guide2 = new Guide { Id = Guid.Parse("123e4567-e89b-12d3-a456-426655440001"), Name = "John Connor", IsUnavailable = false };
            
            _guideService = new GuideServices(
                _loggerMock.Object,
                _guideRepositoryMock.Object,
                _baseRepositoryMock.Object,
                _animalCompetencesRepositoryMock.Object,
                _animalRepositoryMock.Object);
        }

        [Fact]
        public async Task GetGuideById_Success_ReturnsValidResponse()
        {

            _guideRepositoryMock.Setup(repo => repo.GetGuideById(_guide.Id)).ReturnsAsync(_guide);

            var result = await _guideService.GetGuideById(_guide.Id);
            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(_guide, result.Data);
            Assert.Null(result.ErrorMessage);

        }

        [Fact]

        public async Task GetGuideById_GuideNotFound_ReturnsErrorResponse()
        {
            _guideRepositoryMock.Setup(repo => repo.GetGuideById(_guide.Id)).ReturnsAsync((Guide)null);

            var result = await _guideService.GetGuideById(_guide.Id);

            Assert.False(result.IsSuccess);
            Assert.Null(result.Data);
            Assert.Equal("Kan inte hitta guide med det angivna id't",result.ErrorMessage);
        }

    }
}

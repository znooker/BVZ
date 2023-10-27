using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Application.Services;
using BVZ.BVZ.Domain.Models.Zoo.Guides;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVZ.Tests.ApplicationServices.Guides
{
    public class SoftDeleteGuideTest
    {
        private Mock<ILogger<GuideServices>> _loggerMock;
        private Mock<IGuideRepository> _guideRepositoryMock;
        private Mock<ITransaction> _baseRepositoryMock;
        private Mock<IAnimalCompetencesRepository> _animalCompetencesRepositoryMock;
        private Mock<IAnimalRepository> _animalRepositoryMock;

        private Guide _guide;
        private Guide _guide2;
        private GuideServices _guideService;

        public SoftDeleteGuideTest()
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
        public async Task SoftDeleteGuide_Success_ReturnsValidResponse()
        {
            _guideRepositoryMock.Setup(repo => repo.GetGuideById(_guide.Id)).ReturnsAsync(_guide);
            _guideRepositoryMock.Setup(repo => repo.SoftDeleteGuide(_guide)).ReturnsAsync(true);

            var result = await _guideService.SoftDeleteGuide(_guide.Id);

            Assert.True(result.IsSuccess);
            Assert.Equal($"{_guide.Name} är avskedad.", result.Data);
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.UserInfo);

        }

        [Fact]
        public async Task SoftDeleteGuide_CouldNotDeleteGuide_ReturnsErrorResponse()
        {
            _guideRepositoryMock.Setup(repo => repo.GetGuideById(_guide.Id)).ReturnsAsync(_guide);
            _guideRepositoryMock.Setup(repo => repo.SoftDeleteGuide(_guide)).ReturnsAsync(false);

            var result = await _guideService.SoftDeleteGuide(_guide.Id);

            Assert.False(result.IsSuccess);
            Assert.Null(result.Data);
            Assert.Equal("Gick inte att ta bort den valda guiden. Kontakta admin.",result.ErrorMessage);
            Assert.Null(result.UserInfo);
        }

        [Fact]
        public async Task SoftDeleteGuide_CouldNotFindSelecedGuideToDelete_ReturnsErrorResponse()
        {
            _guideRepositoryMock.Setup(repo => repo.GetGuideById(_guide.Id)).ReturnsAsync((Guide)null);
            _guideRepositoryMock.Setup(repo => repo.SoftDeleteGuide(_guide)).ReturnsAsync(false);

            var result = await _guideService.SoftDeleteGuide(_guide.Id);

            Assert.False(result.IsSuccess);
            Assert.Null(result.Data);
            Assert.Equal("Hittade ingen guide att ta bort.", result.ErrorMessage);
            Assert.Null(result.UserInfo);
        }
    }
}

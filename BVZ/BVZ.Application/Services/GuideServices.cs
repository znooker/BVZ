using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Domain.Models.Zoo.Guides;
using BVZ.BVZ.Infrastructure.Data;
using BVZ.BVZ.Infrastructure.Repositories;

namespace BVZ.BVZ.Application.Services
{
    public class GuideServices
    {
        private readonly ILogger<GuideServices> _logger;
        private readonly IGuideRepository _guideRepository;
        private readonly ITransaction _baseRepository;

        public GuideServices(
            ILogger<GuideServices> logger,
            IGuideRepository guideRepository,
            ITransaction baseRepository)
        {
            _logger = logger;
            _guideRepository = guideRepository;
            _baseRepository = baseRepository;
        }

        public async Task<ServiceResponse<List<Guide>>> GetAllGuides()
        {
            ServiceResponse<List<Guide>> response = new ServiceResponse<List<Guide>>();
            var list = await _guideRepository.GetAllGuides();
            if(list == null || list.Count == 0)
            {
                response.IsSuccess = false;
                response.ErrorMessage = "Kan inte hitta några guider";
                return response;
            }

            response.IsSuccess = true;
            response.Data=list;
            return response;

        }
    }
}

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

        public async Task<ServiceResponse<Guide>> GetGuideById(Guid id)
        {
            ServiceResponse<Guide> response = new ServiceResponse<Guide>();
            var guide = await _guideRepository.GetGuideById(id);
            if (guide == null)
            {
                response.IsSuccess = false;
                response.ErrorMessage = "Kan inte hitta guide med det angivna id't";
                return response;
            }

            response.IsSuccess = true;
            response.Data = guide;
            return response;
        }

        public async Task<ServiceResponse<string>> SoftDeleteGuide(Guid guideId)
        {
            ServiceResponse<string> result = new ServiceResponse<string>();

            var guide = await _guideRepository.GetGuideById(guideId);
            if (guide == null)
            {
                result.IsSuccess = false;
                result.UserInfo = "Hittade ingen guide att ta bort.";
                return result;
            }
            guide.IsArchived = true;

            if (!await _guideRepository.SoftDeleteGuide(guide))
            {
                result.IsSuccess = false;
                result.UserInfo = "Gick inte att ta bort den valda guiden. Kontakta admin.";
                return result;
            }
            result.IsSuccess = true;
            result.Data = $"{guide.Name} är avskedad.";
            return result;
        }
    }
}

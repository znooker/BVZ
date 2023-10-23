using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Domain.Models.DTOs.Visitor;

namespace BVZ.BVZ.Application.Services
{
    public class VisitorServices
    {
        private readonly ILogger<VisitorServices> _logger;
        private readonly IVisitorRepository _visitorRepository;

        public VisitorServices(
            ILogger<VisitorServices> logger,
            IVisitorRepository visitorRepository)
        {
            _logger = logger;
            _visitorRepository = visitorRepository;
        }

        public async Task<ServiceResponse<List<AllVisitorsAndLinkedToursDTO>>> GetAllVisitorsAndLinkedTours()
        {
            ServiceResponse<List<AllVisitorsAndLinkedToursDTO>> response = new ServiceResponse<List<AllVisitorsAndLinkedToursDTO>>();
            var list = await _visitorRepository.GetAllVisitorsAndLinkedTours();
            if (list == null || list.Count == 0) 
            {
                response.IsSuccess = false;
                response.UserInfo = "Finns ingen data att visa.";
                return response;
            }
            response.IsSuccess = true;
            response.Data = list;
            return response;
        }
        
    }
}

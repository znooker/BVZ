using BVZ.BVZ.Domain.Models.DTOs.Visitor;
using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Domain.Models.Zoo.Guides;

namespace BVZ.BVZ.Application.Interfaces
{
    public interface IVisitorRepository
    {
        Task<List<AllVisitorsAndLinkedToursDTO>> GetAllVisitorsAndLinkedTours();
        Task<List<Visitor>> GetVisitsByDate(DateTime date);
    }
}

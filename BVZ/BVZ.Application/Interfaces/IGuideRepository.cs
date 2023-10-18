using BVZ.BVZ.Domain.Models.Zoo.Guides;

namespace BVZ.BVZ.Application.Interfaces
{
    public interface IGuideRepository
    {
        Task<bool> AddGuide(Guide guide);
        Task<bool> UpdateGuide(Guide guide);
        Task<bool> DeleteGuide(Guide guide);
        Task<bool> DeleteGuideById(Guid id);
        Task<IEnumerable<Guide>> GetAllGuides();
        Task<Guide> GetGuideById(Guid id);
    }
}

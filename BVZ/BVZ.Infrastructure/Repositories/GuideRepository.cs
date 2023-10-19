using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Domain.Models.Zoo.Guides;
using BVZ.BVZ.Infrastructure.Data;

namespace BVZ.BVZ.Infrastructure.Repositories
{
    public class GuideRepository : IGuideRepository
    {

        private readonly ZooDbContext _context;
        public GuideRepository(ZooDbContext context)
        {
            _context = context;
        }


        public Task<bool> AddGuide(Guide guide)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGuide(Guide guide)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGuideById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Guide>> GetAllGuides()
        {
            throw new NotImplementedException();
        }

        public Task<Guide> GetGuideById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateGuide(Guide guide)
        {
            throw new NotImplementedException();
        }
    }
}

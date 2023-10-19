using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Domain.Models.Zoo.Guides;
using BVZ.BVZ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BVZ.BVZ.Infrastructure.Repositories
{
    public class GuideRepository : IGuideRepository
    {

        private readonly ZooDbContext _context;
        public GuideRepository(ZooDbContext context)
        {
            _context = context;
        }


        public async Task<bool> AddGuide(Guide guide)
        {
            
                _context.Guides.Add(guide);
                await _context.SaveChangesAsync();
                return true;
           

        }

        public async Task<bool> DeleteGuide(Guide guide)
        {

            try
            {
                _context.Guides.Remove(guide);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {

                throw e;
                
            }
           
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


        public Task<bool> UpdateGuide(Guide guide)
        {
            throw new NotImplementedException();
        }
    }
}

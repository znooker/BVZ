using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Domain.Models.Zoo.Animals;
using BVZ.BVZ.Domain.Models.Zoo.Guides;
using BVZ.BVZ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

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

        public async Task<List<Guid>> GetAnimalsByGuideId(Guid id)
        {
            var animalIds = await _context.AnimalCompetences
                            .Where(ac => ac.GuideId == id)
                            .Select(ac => ac.AnimalId)
                            .ToListAsync();

            return animalIds;
        }

        public async Task<int> GetAnimalVisitsByDateAndAnimal(Guid id, DateTime dateOfVisit)
        {
            int NrOfVisit = await _context.AnimalVisits
                                    .Where(av => av.ZooDay.TodaysDate == dateOfVisit 
                                    && av.AnimalId == id)
                                    .CountAsync();
            return NrOfVisit;
        }
        public async Task<bool> AddAnimalVisit(AnimalVisit animalVisit)
        {
            _context.AnimalVisits.Add(animalVisit);
            return await Task.FromResult(_context.SaveChanges() > 0);
        }
    }
}

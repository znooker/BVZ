using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Domain.Models.Zoo.Guides;
using BVZ.BVZ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BVZ.BVZ.Infrastructure.Repositories
{
    public class AnimalCompetencesRepository : BaseRepository, IAnimalCompetencesRepository
    {
        private readonly ZooDbContext _context;

        public AnimalCompetencesRepository(ZooDbContext context) : base(context)
        {
          _context = context;
        }

        
        public async Task<bool> AddCompetences(List<AnimalCompetence> competences)
        {
            _context.AddRangeAsync(competences);
            return await Save();
        }

        public async Task<bool> DeleteCompetences(List<AnimalCompetence> competences)
        {
            //_context.RemoveRange(competences.Where(x => x.GuideId == x.Guide.Id));
            _context.RemoveRange(competences);
            return await Save();
        }

        public async Task<List<AnimalCompetence>> GetCompetencesByGuideId(Guid GuideId)
        {
           return await _context.AnimalCompetences.Where(x => x.GuideId == GuideId).ToListAsync();
        }
    }
    
    
}

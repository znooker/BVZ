using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BVZ.BVZ.Infrastructure.Repositories
{
    public class TourRepository : BaseRepository, ITourRepository
    {
        private readonly ZooDbContext _context;
        public TourRepository(ZooDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> AddZooTour(ZooTour zootour)
        {
            _context.Add(zootour);
            return await Save();
        }

        public async Task<List<Tour>> GetAllTours()
        {
            return await _context.Tours
                            .Include(t => t.Guide)
                            .Include(tp => tp.TourParticipants)
                            .ToListAsync();

        }

        public async Task<List<ZooTour>> GetZooToursByDate(DateTime day)
        {
            return await _context.ZooTours
                        .Include(z => z.Tour)
                            .ThenInclude(t => t.Guide)
                        .Where(z => z.DateOfTour.Date == day.Date 
                        && z.NrOfParticipants < 5)
                        .ToListAsync();
        }

        public async Task<ZooTour> GetZooTourById(Guid id)
        {
            return await _context.ZooTours
                            .Include(z => z.Tour)
                               .ThenInclude(t => t.Guide)
                            .Include(z => z.ZooDay)
                            .Where(zt => zt.Id == id).SingleOrDefaultAsync();   
        }

        public async Task<bool> UpdateZooTour(ZooTour zootour)
        {
            _context.ZooTours.Update(zootour);
            return await Save();
        }

        public Task<bool> CreateTour(Tour zootour)
        {
            _context.Tours.Add(zootour);
            return Save();
        }
    }
}

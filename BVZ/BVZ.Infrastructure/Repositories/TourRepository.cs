using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BVZ.BVZ.Infrastructure.Repositories
{
    public class TourRepository : ITourRepository
    {
        private readonly ZooDbContext _context;

        public TourRepository(ZooDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddZooTour(ZooTour zootour)
        {
            _context.Add(zootour);
            return await Task.FromResult(_context.SaveChanges() > 0);
        }

        public async Task<List<Tour>> GetAllTours()
        {
            return await _context.Tours
                            .Include(t => t.Guide)
                            .ToListAsync();

        }

        public async Task<List<ZooTour>> GetZooToursByDate(DateTime day)
        {
            return await _context.ZooTours
                        .Include(z => z.Tour)
                            .ThenInclude(t => t.Guide)
                        .Where(z => z.DateOfTour == day)
                        .ToListAsync();
        }
    }
}

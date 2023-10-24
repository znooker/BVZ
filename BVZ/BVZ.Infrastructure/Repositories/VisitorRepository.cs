using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Domain.Models.DTOs.Visitor;
using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BVZ.BVZ.Infrastructure.Repositories
{
    public class VisitorRepository : BaseRepository, IVisitorRepository
    {
        private readonly ZooDbContext _context;

        public VisitorRepository(ZooDbContext context) : base(context)
        {
            _context=context;
        }

        public async Task<List<AllVisitorsAndLinkedToursDTO>> GetAllVisitorsAndLinkedTours()
        {
            return await _context.Visitors
               .Include(tp => tp.TourParticipants)
               .ThenInclude(t => t.Tour).Select(x => new AllVisitorsAndLinkedToursDTO
               {
                   VisitorId = x.Id,
                   Alias = x.Alias,
                   TicketDate = x.TicketDate,
                   Tours = x.TourParticipants.Select(tp => tp.Tour).ToList()
                   
               }).ToListAsync();
        }

        public Task<List<Visitor>> GetVisitsByDate(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}

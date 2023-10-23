using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Domain.Models.Zoo;
using BVZ.BVZ.Domain.Models.Zoo.Animals;
using BVZ.BVZ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BVZ.BVZ.Infrastructure.Repositories
{
    public class ZooRepository : BaseRepository, IZooRepository
    {
        private readonly ZooDbContext _context;
        public ZooRepository(ZooDbContext context) : base(context)
        {
            _context = context;
        }
        Task<bool> IZooRepository.AddAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        Task<bool> IZooRepository.AddNewZooDay(ZooDay zooday)
        {
            _context.Add(zooday);
            return Task.FromResult(_context.SaveChanges() > 0);
        }

        Task<bool> IZooRepository.DeleteAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        Task<bool> IZooRepository.UpdateAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddVisitor(Visitor visitor)
        {
            _context.Visitors.Add(visitor);
            return await Save();
        }
        public async Task<bool> AddTourParticipant(TourParticipant tourParticipant)
        {
            _context.TourParticipants.Add(tourParticipant);
            return await Save();
        }

        public async Task<Animal> GetAnimalById(Guid id)
        { 
            return await _context.Animals.Where(a => a.Id == id).SingleOrDefaultAsync();   
        }

        public async Task<ICollection<Visitor>> GetDailyZooVisitors(DateTime today)
        {
            return await _context.Visitors
                .Where(v => v.TicketDate.Date == today.Date)
                .ToListAsync();
        }
    }
}

using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Domain.Models.Zoo;
using BVZ.BVZ.Domain.Models.Zoo.Animals;
using BVZ.BVZ.Infrastructure.Data;

namespace BVZ.BVZ.Infrastructure.Repositories
{
    public class ZooRepository : IZooRepository
    {
        private readonly ZooDbContext _context;

        public ZooRepository(ZooDbContext context)
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
    }
}

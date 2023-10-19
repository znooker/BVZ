using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Domain.Models.Zoo.Animals;
using BVZ.BVZ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BVZ.BVZ.Infrastructure.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        
        private readonly ZooDbContext _context;
        public AnimalRepository(ZooDbContext context)
        {
            _context = context;
        }

        public Task<bool> AddAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAnimalById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Animal>> GetAllAnimals()
        {
            var result = await _context.Animals.ToListAsync();
            return result;
        }

        public Task<Animal> GetAnimalById(Guid id)
        {
            throw new NotImplementedException();
        }


        public Task<bool> UpdateAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }
    }
}

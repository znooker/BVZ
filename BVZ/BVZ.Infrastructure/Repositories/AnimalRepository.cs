using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Domain.Models.Zoo.Animals;
using BVZ.BVZ.Infrastructure.Data;

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

        public Task<IEnumerable<Animal>> GetAllAnimals()
        {
            throw new NotImplementedException();
        }

        public Task<Animal> GetAnimalById()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }
    }
}

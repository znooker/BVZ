using BVZ.BVZ.Domain.Models.Zoo.Animals;
using BVZ.BVZ.Domain.Models.Zoo.Guides;

namespace BVZ.BVZ.Application.Interfaces
{
    public interface IAnimalRepository
    {
        Task<bool> AddAnimal(Animal animal);
        Task<bool> UpdateAnimal(Animal animal);
        Task<bool> DeleteAnimal(Animal animal);
        Task<bool> DeleteAnimalById(Guid id);
        Task<IEnumerable<Animal>> GetAllAnimals();
        Task<Animal> GetAnimalById(Guid id);

    }
}

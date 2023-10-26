
using BVZ.BVZ.Domain.Models.Zoo.Animals;
using BVZ.BVZ.Domain.Models.Zoo.Guides;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

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

        Task<List<Guid>> GetAnimalsByGuideId(Guid id);
        Task<int> GetAnimalVisitsByDateAndAnimal(Guid id, DateTime dateOfVisit);
        Task<bool> AddAnimalVisit(AnimalVisit animalVisit);

        Task<List<string>> GetAllAnimalTypes();
        Task<List<Animal>> GetUniqeAnimalListByAnimalType(List<string> types);

        


    }
}

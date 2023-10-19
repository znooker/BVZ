using BVZ.BVZ.Domain.Models.Zoo;
using BVZ.BVZ.Domain.Models.Zoo.Animals;

namespace BVZ.BVZ.Application.Interfaces
{
    public interface IZooRepository
    {
        Task<bool> AddNewZooDay(ZooDay zooday);
        Task<bool> AddAnimal(Animal animal);
        Task<bool> UpdateAnimal(Animal animal);
        Task<bool> DeleteAnimal(Animal animal);
    }
}

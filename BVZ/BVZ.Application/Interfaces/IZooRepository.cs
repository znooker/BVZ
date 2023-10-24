using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Domain.Models.Zoo;
using BVZ.BVZ.Domain.Models.Zoo.Animals;
using BVZ.BVZ.Infrastructure.Repositories;

namespace BVZ.BVZ.Application.Interfaces
{
    public interface IZooRepository
    {
        
        Task<ZooDay> GetZooDayByDate(DateTime date);
        Task<bool> AddNewZooDay(ZooDay zooday);
        Task<bool> AddNewZooTour(ZooTour zooTour);
        Task<bool> AddAnimal(Animal animal);
        Task<bool> UpdateAnimal(Animal animal);
        Task<bool> DeleteAnimal(Animal animal);
        Task<Guid> GetZooDayIdByTodaysDate(DateTime date);
        Task<bool> AddVisitor(Visitor visitor);
        Task<ICollection<Visitor>> GetDailyZooVisitors(DateTime today);
        Task<bool> AddTourParticipant(TourParticipant tourParticipant);
        Task<Animal> GetAnimalById(Guid id);
    }
}

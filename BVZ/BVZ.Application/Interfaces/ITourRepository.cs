using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Domain.Models.Zoo.Animals;

namespace BVZ.BVZ.Application.Interfaces
{
    public interface ITourRepository
    {
       Task<List<Tour>> GetAllTours();
       Task<List<ZooTour>> GetZooToursByDate(DateTime day);
        
       Task<bool> AddZooTour(ZooTour zootour);
    }
}

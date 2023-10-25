using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Domain.Models.Zoo;
using BVZ.BVZ.Domain.Models.Zoo.Animals;

namespace BVZ.BVZ.Application.Interfaces
{
    public interface ITourRepository
    {
       Task<ZooTour> GetZooTourById(Guid id);
       Task<Tour> GetTourById(Guid id);
       Task<ZooTour> GetBookingOptionsForTour(Guid id, DateTime date);
       Task<List<Tour>> GetAllTours();
       Task<List<ZooTour>> GetZooToursByDate(DateTime day);
       Task<List<Tour>> GetToursAvailableToday(DateTime date);
        
       Task<bool>CreateTour(Tour tour);

       Task<bool> UpdateTour(Tour tour);
        
       Task<bool> AddZooTour(ZooTour zootour);
       Task<bool> UpdateZooTour(ZooTour zootour);
    }
}

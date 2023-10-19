using BVZ.BVZ.Domain.DomainExceptions;
using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Domain.Models.Zoo;
using BVZ.BVZ.Domain.Models.Zoo.Animals;
using BVZ.BVZ.Infrastructure.Data;
using BVZ.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Imaging;

namespace BVZ.BVZ.Application.Services
{
    public class MockTourService
    {
        private readonly ZooDbContext _context;

        public MockTourService(ZooDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ZooTour>>>NewDay()
        {
            ServiceResponse<List<ZooTour>> response = new ServiceResponse<List<ZooTour>>();
            ZooDay zooDay = new ZooDay();
            // Spara zooDay i DB..

            var tours = _context.Tours.ToList();
            if (tours == null || !tours.Any())
            {
                response.IsSuccess = false;
                response.ErrorMessage = "List of tours is null or empty.";
                return response;
            }

            List<ZooTour> DailyBookableTours = new List<ZooTour>();
            foreach(var tour in tours)
            {
                //if (tour.Guide.IsUnavailable == true) throw new Exception("Temp fix");

                var twoDailyTours = await tour.CreateDailyTours(tour, zooDay);
                if (twoDailyTours != null)
                {
                    foreach(var singleTour in twoDailyTours)
                    {
                        CreateDailyTour(singleTour);
                        DailyBookableTours.Add(singleTour);
                    }
                }
                else break;
            }
            response.IsSuccess = true;
            response.Data = DailyBookableTours;
            return response;

        }
    
        // Senare ett repository-anrop istället..
        private void CreateDailyTour(ZooTour zooTour)
        {
            _context.ZooTours.Add(zooTour);
            _context.SaveChanges();
        }


        public void BookTour(ZooTour zootour)
        {
            // kolla animals
            var guide = zootour.Tour.Guide;
            List<Animal> AnimalsVisited = new List<Animal>();
            foreach(var comp in guide.AnimalCompetences)
            {
                AnimalsVisited.Add(comp.Animal);
            }

            // Method checking each animal
            // if(Animal.AnimalVisit.ZooDay.TodaysDate < 2)
            // Ok för att boka tour.

            // Skapa ny AnimalVisit för varje animal i AnimalsVisited.

            ZooDay zooDay = new ZooDay();

            var tours = _context.Tours.ToList();
            //CreateZooTours(zooDay, tours);

        }
    }
    
}

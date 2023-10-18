using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Domain.Models.Zoo;
using BVZ.BVZ.Domain.Models.Zoo.Animals;
using BVZ.BVZ.Infrastructure.Data;
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

        public void NewDay()
        {
            // Arkivera gamla zooday?

            ZooDay zooDay = new ZooDay();

            var tours = _context.Tours.ToList();
            CreateZooTours(zooDay, tours);

        }

        public void CreateZooTours(ZooDay zooDay, List<Tour> tours)
        {
            if (tours == null || !tours.Any()) return;

            List<string> listOfTours = new List<string>();
            foreach (var tour in tours)
            {
                
                listOfTours.Add(tour.TourName);

                foreach (var newTour in listOfTours)
                {
                    if(tour.Guide.IsUnavailable == true) break;
                   
                    if(newTour == tour.TourName)
                    {
                        if(tour.DailyBookingCount < 2)
                        {
                            CreateZooTour(tour, zooDay);
                            tour.DailyBookingCount++;
                            break;
                        }

                        if (tour.DailyBookingCount >= 2)
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (tour.DailyBookingCount < 2)
                        {
                            CreateZooTour(tour, zooDay);
                            tour.DailyBookingCount++;
                            break;
                        }

                        if (tour.DailyBookingCount >= 2)
                        {
                            break;
                        }
                    }
                }
            }
        }
        private void CreateZooTour(Tour tour, ZooDay zooDay)
        {
            var zooTour = new ZooTour(tour, zooDay);
            _context.ZooTours.Add(zooTour);
            _context.Tours.Update(tour);
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
            CreateZooTours(zooDay, tours);

        }
    }
    
}

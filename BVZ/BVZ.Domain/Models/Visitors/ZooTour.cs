using BVZ.BVZ.Domain.Models.Zoo;

namespace BVZ.BVZ.Domain.Models.Visitors
{
    public class ZooTour
    {
        public Guid Id { get; set; }

        public Tour Tour { get; set; }
        public Guid TourID { get; set; }

        public ZooDay ZooDay { get; set; }
        public Guid ZooDayId { get; set; }

        public DateTime DateOfTour { get; set; }
        public bool IsMorningTour { get; set; }
        public int NrOfParticipants { get; set; } = 0;

        public ZooTour() 
        {
            Id = Guid.NewGuid();
        }

        public ZooTour(Tour tour, ZooDay zooDay, bool isMorningTour, DateTime dateOfTour)
        {
            Tour = tour;
            ZooDay = zooDay;
            IsMorningTour = isMorningTour;
            DateOfTour= dateOfTour;
        }
    }
}

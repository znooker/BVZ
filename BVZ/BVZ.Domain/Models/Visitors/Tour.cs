using BVZ.BVZ.Domain.Models.Zoo;
using BVZ.BVZ.Domain.Models.Zoo.Guides;
using BVZ.Models;

namespace BVZ.BVZ.Domain.Models.Visitors
{
    public class Tour
    {
        public Guid Id { get; set; }
        public string TourName { get; set; }
        public string Description { get; set; }
        public int DailyBookingCount { get; set; } = 0;
        public int NrOfParticipants { get; private set; } = 0;
        public bool TourCompleted { get; private set; } = false;

        public ICollection<ZooTour> ZooTours { get; set; }
        public Guide Guide { get; set; }
        public Guid GuideId { get; set; }
        public ICollection<TourParticipant> TourParticipants { get; set; }

        public Tour(Guid id, string tourName, string description, Guide guide, ICollection<TourParticipant> tourParticipants)
        {
            Id = Guid.NewGuid();
            TourName = tourName;
            Description = description;
            Guide = guide;
            TourCompleted = false;
        }
        public Tour() { }

        private bool CheckIfSpotIsAvailable(Tour tour, int nrOfPersonsToBookTour)
        {
            if (tour.NrOfParticipants >= 5) 
            {
                return false;
            }

            if ((tour.NrOfParticipants + nrOfPersonsToBookTour) >= 5)
            {
                return false;
            }
            tour.NrOfParticipants = tour.NrOfParticipants + nrOfPersonsToBookTour;
            return true;
        }

    
   

        private void StartTour(Tour tour)
        {
            tour.TourCompleted = true;
        }
    }
}

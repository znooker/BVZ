using BVZ.BVZ.Domain.Models.Zoo.Animals;
using BVZ.BVZ.Domain.Models.Zoo.Guides;
using BVZ.Models;

namespace BVZ.BVZ.Domain.Models.Visitors
{
    public class Tour
    {
        public Guid Id { get; set; }
        public string TourName { get; set; }
        public string Description { get; set; }
        public int NrOfParticipants { get; private set; }
        public bool TourCompleted { get; private set; }
        public DateTime TourDate { get; set; }

        public ZooDay ZooDay { get; set; }
        public Guide Guide { get; set; }
        public ICollection<TourParticipant> TourParticipants { get; set; }

        public Tour(Guid id, string tourName, string description, int nrOfParticipants, Guide guide, ICollection<TourParticipant> tourParticipants)
        {
            Id = Guid.NewGuid();
            TourName = tourName;
            Description = description;
            NrOfParticipants = 0;
            Guide = guide;
            TourParticipants = tourParticipants;
            TourCompleted = false;
        }
        public Tour()
        {

        }

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

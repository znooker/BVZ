using BVZ.BVZ.Domain.Models.Visitors;

namespace BVZ.Models.Tour
{
    public class DisplayAllToursViewModel
    {
        // I commented out this, gave build errors, there is already one TourOfTheDay in the class
        // which one do you want to keep??
        //public List<ZooTour> ToursOfTheDay { get; set; }
        public List<Visitor>? Confirmation { get; set; }

        public List<ZooTour>? ToursOfTheDay { get; set; }
        
        public List<BVZ.Domain.Models.Visitors.Tour>? AllTours { get; set; }

        public string? Message { get; set; }
        public string? Status { get; set; }
    }
}
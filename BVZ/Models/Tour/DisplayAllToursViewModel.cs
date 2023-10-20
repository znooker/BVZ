using BVZ.BVZ.Domain.Models.Visitors;

namespace BVZ.Models.Tour
{
    public class DisplayAllToursViewModel
    {

        public List<ZooTour> ToursOfTheDay { get; set; }
        public List<Visitor>? Confirmation { get; set; }

        public List<ZooTour>? ToursOfTheDay { get; set; }
        
        public List<BVZ.Domain.Models.Visitors.Tour>? AllTours { get; set; }


    }
}
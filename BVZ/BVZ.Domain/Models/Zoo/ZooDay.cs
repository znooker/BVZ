using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Domain.Models.Zoo.Animals;

namespace BVZ.BVZ.Domain.Models.Zoo
{
    public class ZooDay
    {
        public Guid Id { get; set; }
        public DateTime TodaysDate { get; set; }
        public bool Archived { get; set; } = false;
        public ICollection<ZooTour> ZooTours { get; set; }

        public ZooDay()
        {
            Id = Guid.NewGuid();
            TodaysDate = DateTime.Today;
        }

    }
}

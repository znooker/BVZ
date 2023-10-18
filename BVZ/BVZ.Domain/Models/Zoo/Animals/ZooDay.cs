using BVZ.BVZ.Domain.Models.Visitors;

namespace BVZ.BVZ.Domain.Models.Zoo.Animals
{
    public class ZooDay
    {
        public Guid Id { get; set; }
        public DateTime TodaysDate { get; set; }
        public bool Archived { get; set; }
        public ICollection<AnimalVisit> AnimalVisits { get; set; }
        public ICollection<Tour> DailyTours { get; set; }
        public ZooDay()
        {

        }

    }
}

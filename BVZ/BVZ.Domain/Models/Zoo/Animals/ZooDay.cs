namespace BVZ.BVZ.Domain.Models.Zoo.Animals
{
    public class ZooDay
    {
        public Guid Id { get; set; }
        public DateTime TodaysDate { get; set; }
        public bool Archieved { get; set; }
        public ICollection<AnimalVisit> AnimalVisits { get; set; }

        public ZooDay()
        {

        }
    }
}

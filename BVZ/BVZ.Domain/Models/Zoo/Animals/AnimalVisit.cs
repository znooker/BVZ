namespace BVZ.BVZ.Domain.Models.Zoo.Animals
{
    public class AnimalVisit
    {
        public Guid Id { get; set; }

        public Animal Animal { get; set; }
        public Guid AnimalId { get; set; }

        public ZooDay ZooDay { get; set; }
        public Guid ZooDayId { get; set; }

        public DateTime VisitDate { get; set; }

        public AnimalVisit(ZooDay zooDay, Animal animal)
        {
            ZooDay = zooDay;
            Animal = animal;
            VisitDate= DateTime.Today;
        }
        public AnimalVisit()
        {

        }
    }
}

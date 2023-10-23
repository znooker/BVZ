namespace BVZ.BVZ.Domain.Models.Zoo.Animals
{
    public class AnimalVisit
    {
        public Guid Id { get; set; }

        public Animal Animal { get; set; }
        public Guid AnimalId { get; set; }

        public DateTime VisitDate { get; set; }

        public AnimalVisit(Animal animal)
        {
            Animal = animal;
            VisitDate= DateTime.Today;
        }
        public AnimalVisit()
        {

        }
    }
}

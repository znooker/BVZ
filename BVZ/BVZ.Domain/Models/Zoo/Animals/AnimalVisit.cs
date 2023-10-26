using BVZ.BVZ.Domain.Models.Zoo.Animals.ValueTypes;

namespace BVZ.BVZ.Domain.Models.Zoo.Animals
{
    public class AnimalVisit
    {
        public Guid Id { get; set; }

        public AnimalArchetype AnimalArchetype { get; set; }

        public DateTime VisitDate { get; set; }

        public AnimalVisit(AnimalArchetype animalArchetype)
        {
            AnimalArchetype = animalArchetype;
            VisitDate = DateTime.Today;
        }
        public AnimalVisit()
        {

        }
    }
}

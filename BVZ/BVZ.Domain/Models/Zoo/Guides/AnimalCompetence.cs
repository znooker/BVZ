using BVZ.BVZ.Domain.Models.Zoo.Animals;

namespace BVZ.BVZ.Domain.Models.Zoo.Guides
{
    public class AnimalCompetence
    {
        public Guid Id { get; set; }

        public Guide Guide { get; set; }
        public Guid GuideId { get; set; }

        public Animal Animal { get; set; }
        public Guid AnimalId { get; set; }

        public AnimalCompetence()
        {

        }

        public AnimalCompetence(Animal animal, Guide guide)
        {
            Id = Guid.NewGuid();
            Animal = animal;
            Guide = guide;
        }
    }
}

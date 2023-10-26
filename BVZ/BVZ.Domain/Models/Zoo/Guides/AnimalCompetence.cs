using BVZ.BVZ.Domain.Models.Zoo.Animals;
using BVZ.BVZ.Domain.Models.Zoo.Animals.ValueTypes;

namespace BVZ.BVZ.Domain.Models.Zoo.Guides
{
    public class AnimalCompetence
    {
        public Guid Id { get; set; }

        public Guide Guide { get; set; }
        public Guid GuideId { get; set; }

        public AnimalArchetype AnimalArchetype { get; set; }

        public AnimalCompetence()
        {

        }

        public AnimalCompetence(Guide guide, AnimalArchetype animalArchetype)
        {
            Id = Guid.NewGuid();
            Guide = guide;
            AnimalArchetype = animalArchetype;
        }
    }
}

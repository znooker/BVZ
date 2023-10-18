using BVZ.BVZ.Domain.Models.Zoo.Animals;

namespace BVZ.BVZ.Domain.Models.Zoo.Guides
{
    public class Guide
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<AnimalCompetence> GuideCompetences { get; set; }

        public Guide()
        { }

        public Guide(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}

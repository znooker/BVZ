using BVZ.BVZ.Domain.Models.Zoo.Animals.ValueTypes;
using BVZ.BVZ.Domain.Models.Zoo.Guides;

namespace BVZ.BVZ.Domain.Models.Zoo.Animals
{

    public abstract class Animal
    {
        public Guid Id { get; set; }
        public string AnimalName { get; set; }
        public  string AnimalType { get; set; }
        public Specie Specie { get; set; }
        public int DailyVisits { get; set; }

        public ICollection<AnimalVisit> AnimalVisits { get; set; }
        public ICollection<AnimalCompetence> AnimalCompentencies { get; set; }

        public virtual void Move()
        {
            Console.WriteLine("Varelsen rör sig framåt på något okänt sätt..");
        }
    }
}

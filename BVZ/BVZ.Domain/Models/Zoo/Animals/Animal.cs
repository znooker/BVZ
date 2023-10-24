using BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Air;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Land;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Water;
using BVZ.BVZ.Domain.Models.Zoo.Animals.ValueTypes;
using BVZ.BVZ.Domain.Models.Zoo.Guides;
using System.Runtime.CompilerServices;

namespace BVZ.BVZ.Domain.Models.Zoo.Animals
{

    public abstract class Animal
    {
        public Guid Id { get; set; }
        public string AnimalName { get; set; }
        public string AnimalType { get; set; }
        public Specie Specie { get; set; }
        public int DailyVisits { get; set; }

        public bool IsArchived { get; set; } = false;

        public ICollection<AnimalVisit> AnimalVisits { get; set; }
        public ICollection<AnimalCompetence> AnimalCompentencies { get; set; }

        public virtual string Move()
        {
            return "Varelsen rör sig framåt på något okänt sätt..";
        }
        public virtual string MakeSound()
        {
            return "Djuret frambringar inga som helst ljud";
        }


        public class AnimalFactory
        {
            public Animal CreateAnimal(string animalType)
            {
                switch (animalType)
                {
                    // Land
                    case "Ozelot":
                        return new Ozelot();
                    case "Okapi":
                        return new Okapi();
                    case "Cheetah":
                        return new Cheetah();
                    // Air
                    case "BaldEagle":
                        return new BaldEagle();
                    case "NorwegianBlueParrot":
                        return new NorwegianBlueParrot();

                    // Water
                    case "MorayEel":
                        return new MorayEel();
                    case "ElectricEel":
                        return new ElectricEel();


                    default:
                        throw new NotSupportedException($"The animal type {animalType} is not supported.");
                }
            }
        }
    }
}

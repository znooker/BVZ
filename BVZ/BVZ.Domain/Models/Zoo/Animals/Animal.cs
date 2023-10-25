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
                        var ozelot = new Ozelot();
                        ozelot.Specie = Specie.Mammal;
                        return ozelot;

                    case "Okapi":
                        var okapi = new Okapi();
                        okapi.Specie = Specie.Mammal;
                        return okapi;

                    case "Cheetah":
                        var cheetah = new Cheetah();
                        cheetah.Specie = Specie.Mammal;
                        return cheetah;

                    // Air
                    case "BaldEagle":
                        var eagle = new BaldEagle();
                        eagle.Specie = Specie.Bird;
                        return eagle;

                    case "NorwegianBlueParrot":
                        var nbp = new NorwegianBlueParrot();
                        nbp.Specie = Specie.Bird;
                        return nbp;

                    // Water
                    case "MorayEel":
                        var moray = new MorayEel();
                        moray.Specie = Specie.Fish;
                        return moray;

                    case "ElectricEel":
                        var electric = new ElectricEel();
                        electric.Specie = Specie.Fish;
                        return electric;


                    default:
                        throw new NotSupportedException($"The animal type {animalType} is not supported.");
                }
            }
        }
    }
}

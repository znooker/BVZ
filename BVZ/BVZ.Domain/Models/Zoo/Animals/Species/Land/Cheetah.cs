using BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Air;
using BVZ.BVZ.Domain.Models.Zoo.Animals.ValueTypes;

namespace BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Land
{
    public class Cheetah : LandHabitat
    {
        public override double Speed { get; set; }

        public Cheetah()
        {
        }
        public Cheetah(string? name)
        {
            Id = Guid.NewGuid();
            AnimalName = "Cheetah";
            Specie = Specie.Mammal;
            DailyVisits = 0;
            Speed = 70;
        }

        public override string Run()
        {
            return "Det går så fort så fort..";
        }

        public override string MakeSound()
        {
            return "Ett rullande morrande från det höga gräset.. Nu är det är klippt!";
        }

        public override string DisplayAnimalProperties(Animal? animal)
        {
            if (animal is Cheetah cheetah && animal is not null)
            {
                return "Den här geopardens maxhastighet är: " + cheetah.Speed + " km/h.";
            }
            return "Det finns inga nämnvärda egenskaper för den här djurarten.";
        }

    }
}



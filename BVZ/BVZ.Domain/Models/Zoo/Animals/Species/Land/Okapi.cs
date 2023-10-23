using BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats;

namespace BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Land
{
    public class Okapi : LandHabitat
    {
        public override double Speed { get; set; }

        public override string Move()
        {
            return "Okapi kan inte skönjas, den försvinner in i bakgrunden.";
        }
        public override string DisplayAnimalProperties(Animal? animal)
        {
            if (animal is Okapi okapi && animal is not null)
            {
                return "Kommer mer info inom kort för " + okapi.AnimalName + ".";
            }
            return "Det finns inga nämnvärda egenskaper för den här djurarten.";
        }
    }
}

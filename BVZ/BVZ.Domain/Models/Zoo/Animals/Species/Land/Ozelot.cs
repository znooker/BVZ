using BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats;

namespace BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Land
{
    public class Ozelot : LandHabitat
    {
        public override double Speed { get; set; }

        //testmetod

        public override string Move()
        {
            return "Ozelot krälar fram i gräset";
        }

        public string Ozelotmetod()
        {
            return "It smells!";
        }

        public override string DisplayAnimalProperties(Animal? animal)
        {
            if (animal is Ozelot ozelot && animal is not null)
            {
                return "Kommer mer info inom kort för " + ozelot.AnimalName + ".";
            }
            return "Det finns inga nämnvärda egenskaper för den här djurarten.";
        }
    }
}

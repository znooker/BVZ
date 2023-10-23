using BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Land;

namespace BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Water
{
    public class ElectricEel : WaterHabitat
    {
        public override double DivingDepth { get; set; }

        public override string DisplayAnimalProperties(Animal? animal)
        {
            if (animal is ElectricEel ee && animal is not null)
            {
                return "Kommer mer info inom kort för " + ee.AnimalName + ".";
            }
            return "Det finns inga nämnvärda egenskaper för den här djurarten.";
        }
    }
}

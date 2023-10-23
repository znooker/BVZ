using BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats;

namespace BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Water
{
    public class MorayEel : WaterHabitat
    {
        public override double DivingDepth{ get; set; }

        public override string DisplayAnimalProperties(Animal? animal)
        {
            if (animal is MorayEel morayeel && animal is not null)
            {
                return "Kommer mer info inom kort för " + morayeel.AnimalName + ".";
            }
            return "Det finns inga nämnvärda egenskaper för den här djurarten.";
        }
    }
}

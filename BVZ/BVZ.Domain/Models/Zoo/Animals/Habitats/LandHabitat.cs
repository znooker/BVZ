using BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats.Interfaces;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Interfaces;

namespace BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats
{
   

    public abstract class LandHabitat : Habitat, IRun, IMakeSound
    {
        public abstract double Speed { get; set; }

        public virtual string Move()
        {
            return Run();
        }

        public virtual string Run()
        {
            return "Djuret utstötet ett läte.";
        }

        public virtual string MakeSound()
        {
           return "Djuret springer fram över marken.";
        }
    }
}

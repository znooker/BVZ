using BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats.Interfaces;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Interfaces;

namespace BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats
{
   

    public abstract class LandHabitat : Habitat, IRun, IMakeSound
    {
        public abstract double Speed { get; set; }

        public virtual void Move()
        {
            Run();
        }

        public virtual void Run()
        {
            Console.WriteLine("Djuret utstötet ett läte.");
        }

        public virtual void MakeSound()
        {
           Console.WriteLine("Djuret springer fram över marken.");
        }
    }
}

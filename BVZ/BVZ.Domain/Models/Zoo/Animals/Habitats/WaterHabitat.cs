using BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats.Interfaces;

namespace BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats
{
   
    public abstract class WaterHabitat : Habitat, ISwim
    {
        public abstract double DivingDepth { get; set; }

        public void Swim()
        {
            Console.WriteLine("Vattendjuret glider sakta fram i vattnet.");
        }

        public override void Move()
        {
            Swim();
        }
    }
}

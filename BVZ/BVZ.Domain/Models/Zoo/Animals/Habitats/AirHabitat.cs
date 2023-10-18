using BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats.Interfaces;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Interfaces;

namespace BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats
{


    public abstract class AirHabitat : Habitat, IFly, IMakeSound
    {
        public abstract double MaxAltitude { get; set; }

        public virtual void Fly()
        {
            Console.WriteLine("Fågeln flyger fram i luften.");
        }

        public virtual void MakeSound()
        {
            Console.WriteLine("Fågeln utstöter ett krakande läte.");
        }

        public virtual void Move()
        {
            Fly();
        }
    }
}

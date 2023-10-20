using BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats.Interfaces;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Interfaces;

namespace BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats
{


    public abstract class AirHabitat : Habitat, IFly, IMakeSound
    {
        public abstract double MaxAltitude { get; set; }

        public virtual string Fly()
        {
           return "Fågeln flyger fram i luften.";
        }

        public virtual string MakeSound()
        {
            return "Fågeln utstöter ett krakande läte.";
        }

        public virtual string Move()
        {
            return Fly();
        }
    }
}

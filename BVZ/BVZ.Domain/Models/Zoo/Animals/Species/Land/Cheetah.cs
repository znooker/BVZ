using BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats;
using BVZ.BVZ.Domain.Models.Zoo.Animals.ValueTypes;

namespace BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Land
{
    public class Cheetah : LandHabitat
    {
        public string? Name { get; set; }
        public override double Speed { get; set; }

        public Cheetah()
        {
        }
        public Cheetah(string? name)
        {
            Id = Guid.NewGuid();
            AnimalName = "Geopard";
            Name = name;
            Specie = Specie.Mammal;
            DailyVisits = 0;
            Speed = 70;
        }

        public override void Run()
        {
            Console.WriteLine("Det går så fort så fort..");
        }

        public override void MakeSound()
        {
            Console.WriteLine("Ett rullande morrande från det höga gräset innan det är klippt..");
        }

   
    }
}



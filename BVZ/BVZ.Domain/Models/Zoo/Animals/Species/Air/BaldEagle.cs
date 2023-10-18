using BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats;
using BVZ.BVZ.Domain.Models.Zoo.Animals.ValueTypes;

namespace BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Air
{
    public class BaldEagle : AirHabitat
    {
        public string? Name { get; set; }
        public double Wingspan { get; set; }
        public override double MaxAltitude { get; set; }

        public BaldEagle()
        {
        }
        public BaldEagle(string? name, double wingspan)
        {
            Id = Guid.NewGuid();
            AnimalName = "Bald Eagle";
            Name = name;
            Wingspan = wingspan;
            Specie = Specie.Bird;
            DailyVisits = 0;
            MaxAltitude = SetMaxAltitudeForBaldEagle();
            if (MaxAltitude == 0)
            {
                throw new InvalidOperationException("Creature property is not valid.");
            }
        }

        public override void Fly()
        {
            Console.WriteLine("Örnen svävar majestätiskt, högt, högt uppe i luften.");
        }

        public override void MakeSound()
        {
            Console.WriteLine("Ett väldigt skri signalerar att örnen är på jakt!");
        }

        private double SetMaxAltitudeForBaldEagle()
        {
            if (Wingspan > 1.5)
            {
                return MaxAltitude = 1500;
            }
            // Vi kan låtsas att vingspannet inte kan vara bredare för att få simulera lite DDD och enforca
            // lite business-rules.
            if (Wingspan > 2.0 && Wingspan < 3.0)
            {
                return MaxAltitude = 1750;
            }
            else return 0;
        }
    }
}



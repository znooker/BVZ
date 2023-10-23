using BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats;
using BVZ.BVZ.Domain.Models.Zoo.Animals.ValueTypes;
using Newtonsoft.Json;

namespace BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Air
{
    public class BaldEagle : AirHabitat
    {
        public double Wingspan { get; set; }
        public override double MaxAltitude { get; set; }

        public BaldEagle()
        {
        }
        public BaldEagle(double wingspan)
        {
            Id = Guid.NewGuid();
            AnimalName = "Bald Eagle";
            Wingspan = wingspan;
            Specie = Specie.Bird;
            DailyVisits = 0;
            MaxAltitude = SetMaxAltitudeForBaldEagle();
            if (MaxAltitude == 0)
            {
                throw new InvalidOperationException("Creature property is not valid.");
            }
        }

        public override string Fly()
        {
            return "Örnen svävar majestätiskt, högt, högt uppe i luften.";
        }

        public override string MakeSound()
        {
            return "Ett väldigt skri signalerar att örnen är på jakt!";
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

        public override string DisplayAnimalProperties(Animal? animal)
        {
            if (animal is BaldEagle baldEagle && animal is not null)
            {
                return "Havsörnen har ett vingspann på " + baldEagle.Wingspan +
                    " och kan uppnå en maxhöjd på " + baldEagle.MaxAltitude + " meter.";
            }
            return "Det finns inga nämnvärda egenskaper för den här djurarten.";
        }
    }
}



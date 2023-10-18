using BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats;
using BVZ.BVZ.Domain.Models.Zoo.Animals.ValueTypes;

namespace BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Air
{
    public class NorwegianBlueParrot : AirHabitat
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }   
        public string FeatherColor { get; set; }
        public bool CanSpeak { get; set; }

        public override double MaxAltitude { get; set; }

        public NorwegianBlueParrot()
        {
        }
        public NorwegianBlueParrot(string? name, string color, bool canSpeak)
        {
            Id = Guid.NewGuid();
            Name = name;
            AnimalName = "Norwegian Blue Parrot";
            FeatherColor = color;   
            CanSpeak = canSpeak;
            Specie = Specie.Bird;
            DailyVisits = 0;
            MaxAltitude = 1000;
        }
        
        public override void Fly()
        {
            Console.WriteLine("Den norska blå papegojan flyger endast berusad.");
        }

        public override void MakeSound()
        {
            Console.WriteLine("Den norska blå papegojan pratar finska!?");
        }
    }
}

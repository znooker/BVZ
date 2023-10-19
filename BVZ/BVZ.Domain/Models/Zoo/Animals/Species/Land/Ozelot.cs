using BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats;

namespace BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Land
{
    public class Ozelot : LandHabitat
    {
        public override double Speed { get; set; }

        //testmetod
        public string Ozelotmetod()
        {
            return "It smells!";
        }
    }
}

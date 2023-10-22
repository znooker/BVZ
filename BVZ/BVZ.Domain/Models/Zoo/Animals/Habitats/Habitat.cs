namespace BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats
{
    public abstract class Habitat : Animal
    {

        // Skapar ett underlag för att använda dessa properties in ärvda klasser.
        // Om inget namn eller beskrivning bestäms, blir dom ändå registrerade i EF core som null.
        public abstract string DisplayAnimalProperties(Animal? animal);
 
    }
}

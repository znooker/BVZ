using BVZ.BVZ.Domain.Models.Zoo.Animals;

namespace BVZ.Models.Home
{
    public class HomeViewModel
    {
        public List<Animal>? ZooAnimals { get; set; }
        public Animal? Animal { get; set; }
    }
}

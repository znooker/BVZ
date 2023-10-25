using BVZ.BVZ.Domain.Models.Zoo.Animals;

namespace BVZ.Models.Admin.Guide
{
    public class GuideViewModel
    {
        public string GuideName { get; set; }
        public List<Animal> AnimalCompetences { get; set; }

        public List<Guid> AnimalIDs { get; set; }   
    }
}

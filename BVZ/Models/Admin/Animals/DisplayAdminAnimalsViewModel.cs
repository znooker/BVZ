using BVZ.BVZ.Domain.Models.Zoo.Animals;

namespace BVZ.Models.Admin.Animals
{
    public class DisplayAdminAnimalsViewModel
    {
        public List<Animal>? Animals { get; set; }
        public List<string>? AnimalTypes { get; set; }
        public string? Message { get; set; }
        public string? Status { get; set; }
    }
}

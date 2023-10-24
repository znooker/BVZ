using BVZ.BVZ.Domain.Models.Visitors;

namespace BVZ.Models.Admin
{
    public class AdminZootourViewModel
    {
        public List<BVZ.Domain.Models.Visitors.Tour> AvailableTours { get; set; }
        public string? Message { get; set; }
    }
}

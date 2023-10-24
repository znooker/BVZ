using BVZ.BVZ.Infrastructure.Repositories;

namespace BVZ.Models.Admin
{
    public class DisplayAdminAnimalsViewModel
    {
        public Guid TourId { get; set; }
        public string TourName { get; set; }
        public string Description { get; set; }
        public DateTime DateOfTour { get; set; }
        public bool IsMorningTour { get; set; }
        public Guid GuideId { get; set; }
        public List<BVZ.Domain.Models.Zoo.Guides.Guide> Guides { get; set; }

    }

  

}

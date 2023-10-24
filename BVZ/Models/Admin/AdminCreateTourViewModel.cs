using BVZ.BVZ.Infrastructure.Repositories;

namespace BVZ.Models.Admin
{
    public class AdminCreateTourViewModel
    {
        //public Guid TourId { get; set; }
        public string TourName { get; set; }
        public string TourDescription { get; set; }
        public Guid SelectdGuideId { get; set; }
        public BVZ.Domain.Models.Zoo.Guides.Guide Guide { get; set; }
        //public DateTime DateOfTour { get; set; }
        //public bool IsMorningTour { get; set; }
        //public List<BVZ.Domain.Models.Zoo.Guides.Guide> Guides { get; set; }
        //public BVZ.Domain.Models.Zoo.Guides.Guide TourGuide { get; set; }

    }

  

}

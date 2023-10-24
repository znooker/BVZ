using BVZ.BVZ.Domain.Models.Visitors;

namespace BVZ.Models.Admin
{
    public class TimeOfTourViewModel
    {
        public Guid Id { get; set; }
        public bool morning { get; set; }
        public bool afternoon { get; set; }

    }

}

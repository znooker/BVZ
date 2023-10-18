namespace BVZ.BVZ.Domain.Models.Visitors
{
    public class Visitor
    {
        public Guid Id { get; set; }
        public string VisitorCode { get; set; }

        public ICollection<TourParticipant> TourParticipants { get; set;}

    }
}

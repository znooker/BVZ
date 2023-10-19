namespace BVZ.BVZ.Domain.Models.Visitors
{
    public class Visitor
    {
        public Guid Id { get; set; }

        public ICollection<TourParticipant> TourParticipants { get; set;}

        public Visitor()
        {
            Id = Guid.NewGuid();
        }
    }
}

namespace BVZ.BVZ.Domain.Models.Visitors
{
    public class Visitor
    {
        public Guid Id { get; set; }
        public string? Alias { get; set; } = "undefined";
        public ICollection<TourParticipant> TourParticipants { get; set;}

        public Visitor()
        {
            Id = Guid.NewGuid();
        }
        public Visitor(string? alias)
        {
            Id = Guid.NewGuid();
            Alias = alias;
        }
    }
}

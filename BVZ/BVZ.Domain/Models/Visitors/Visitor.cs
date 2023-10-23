namespace BVZ.BVZ.Domain.Models.Visitors
{
    public class Visitor
    {
        public Guid Id { get; set; }
        public string Alias { get; set; } = "undefined";
        public DateTime TicketDate { get; set; }
        public ICollection<TourParticipant> TourParticipants { get; set;}

        public Visitor()
        {
            Id = Guid.NewGuid();
            TicketDate= DateTime.Now;
        }
        public Visitor(string? alias)
        {
            Id = Guid.NewGuid();
            Alias = alias;
            TicketDate = DateTime.Now;
        }
    }
}

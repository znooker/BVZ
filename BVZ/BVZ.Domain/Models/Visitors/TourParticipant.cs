namespace BVZ.BVZ.Domain.Models.Visitors
{
    public class TourParticipant
    {
        public Guid Id { get; set; }

        public Tour Tour { get; set; }
        public Guid TourID { get; set; }

        public Visitor Visitor { get; set; }
        public Guid VisitorId { get; set; }

        public DateTime VisitDate { get; set; }

        public TourParticipant() { }

        public TourParticipant(Tour tour, Visitor visitor, DateTime visitDate)
        {
            Tour = tour;
            Visitor = visitor;
            VisitDate = visitDate;
        }
    }
}

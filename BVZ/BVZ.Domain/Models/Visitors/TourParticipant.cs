using BVZ.BVZ.Domain.Models.Visitors.ValueTypes;

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
        public TourSession TourSession { get; set; }

        public TourParticipant() { }

        public TourParticipant(Tour tour, Visitor visitor, DateTime visitDate, bool isMorningTour)
        {
            Tour = tour;
            Visitor = visitor;
            VisitDate = visitDate;

            if (isMorningTour)
            {
                TourSession = TourSession.Morning;
            }
            else TourSession = TourSession.Afternoon;

            // if visitor.TicketDate == visitDate;

            // else skicka fel tillbaka.
        }
    }
}

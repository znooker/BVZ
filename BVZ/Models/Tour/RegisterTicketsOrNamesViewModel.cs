using BVZ.BVZ.Domain.Models.Visitors;

namespace BVZ.Models.Tour
{
    public class RegisterTicketsOrNamesViewModel
    {
        public Guid Id { get; set; }
        public int NrOfParticipants { get; set; }
        public string HasTickets { get; set; }
    }
}
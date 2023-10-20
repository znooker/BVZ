using BVZ.BVZ.Domain.Models.Visitors;

namespace BVZ.Models.Tour
{
    public class BookingConfirmationViewModel
    {
        public bool BookingSuccessful { get; set; }
        public string? UserMessage { get; set; }
        public List<Visitor>? Visitors { get; set; }

    }
}
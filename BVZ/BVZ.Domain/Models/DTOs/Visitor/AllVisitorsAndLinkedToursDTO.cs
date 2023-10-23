using BVZ.BVZ.Domain.Models.Visitors;
using System.ComponentModel.DataAnnotations.Schema;

namespace BVZ.BVZ.Domain.Models.DTOs.Visitor
{
    public class AllVisitorsAndLinkedToursDTO
    {
        //Visitor
        public Guid VisitorId { get; set; }
        public string Alias { get; set; } = "undefined";
        public DateTime? TicketDate { get; set; }

        //Tour
        public List<Tour>? Tours { get; set; }


    }
}

namespace BVZ.Models.Admin.Guide
{
    public class DisplayAllGuidesViewModel
    {
        public List<BVZ.Domain.Models.Zoo.Guides.Guide>? Guides { get; set; }
        public Guid SelectedGuideID { get; set; }
        public string? Message { get; set; }
        public string? Status { get; set; }
    }
}

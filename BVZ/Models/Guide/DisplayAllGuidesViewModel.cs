
namespace BVZ.Models.Guide
{
    public class DisplayAllGuidesViewModel
    {
        public List<BVZ.Domain.Models.Zoo.Guides.Guide>? Guides { get; set; }
        public Guid SelectedGuideID { get; set; }
    }
}

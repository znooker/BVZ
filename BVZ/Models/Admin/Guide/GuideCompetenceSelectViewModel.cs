using BVZ.BVZ.Domain.Models.Zoo.Animals;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BVZ.Models.Admin.Guide
{
    public class GuideCompetenceSelectViewModel
    {
        public List<string> CompetenceOptions { get; set; }
        public List<string> SelectedCompetences { get; set; }

    }
}

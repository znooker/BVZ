﻿using BVZ.BVZ.Domain.Models.Zoo.Animals;

namespace BVZ.Models.Admin.Guide
{
    public class GuideViewModel
    {
        public string GuideName { get; set; }
        public Guid GuideID { get; set; }
        public BVZ.Domain.Models.Zoo.Guides.Guide Guide { get; set; }
        public List<Animal> AnimalCompetences { get; set; }

        public List<Animal> CurrentAnimalCompetences { get; set; }

        public List<string> CompetenceOptions { get; set; }
        public List<string> SelectedCompetences { get; set; }

        public List<Guid> AnimalIDs { get; set; }
    }
}

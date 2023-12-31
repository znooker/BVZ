﻿using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Domain.Models.Zoo.Animals;

namespace BVZ.BVZ.Domain.Models.Zoo.Guides
{
    public class Guide
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsUnavailable { get; set; } = false;
        public bool IsArchived { get; set; } = false;
        public ICollection<AnimalCompetence> AnimalCompetences { get; set; }
        public ICollection<Tour> Tours { get; set; }

        public Guide()
        { }

        public Guide(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}

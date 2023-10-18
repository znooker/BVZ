using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Domain.Models.Zoo.Animals;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Land;
using BVZ.BVZ.Domain.Models.Zoo.Animals.ValueTypes;
using BVZ.BVZ.Domain.Models.Zoo.Guides;
using Microsoft.EntityFrameworkCore;
using System;

namespace BVZ.BVZ.Infrastructure.Data
{
    public static class SeedZooDay
    {
        public static void SeedFirstOpenDay(this ModelBuilder modelBuilder)
        {
            // Seed start-day object
            modelBuilder.Entity<ZooDay>().HasData(
             new ZooDay
             {
                 Id = new Guid("00000000-0000-0000-0000-123000000000"),
                 TodaysDate = DateTime.Today,
                 Archived = false,
             });

            modelBuilder.Entity<Tour>().HasData(
             new Tour
             {
                Id = new Guid("00000000-0000-0000-0000-444000000000"),
                ZooDayId = new Guid("00000000-0000-0000-0000-123000000000"),
                TourName = "Djungel-Expeditionen",
                Description = "Se djungelns mäktigaste djur..",
                GuideId = new Guid("00000000-0000-0000-0000-000000000009"),
             });

            modelBuilder.Entity<Tour>().HasData(
             new Tour
             {
                 Id = new Guid("00000000-0000-0000-0000-444400000000"),
                 ZooDayId = new Guid("00000000-0000-0000-0000-123000000000"),
                 TourName = "Aqua-expedition",
                 Description = "Se havets vidunder!",
                 GuideId = new Guid("00000000-0000-0000-0000-000000000099"),
             });
        }
    }
}


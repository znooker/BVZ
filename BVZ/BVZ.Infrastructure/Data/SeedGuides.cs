using BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Land;
using BVZ.BVZ.Domain.Models.Zoo.Animals.ValueTypes;
using BVZ.BVZ.Domain.Models.Zoo.Guides;
using Microsoft.EntityFrameworkCore;

namespace BVZ.BVZ.Infrastructure.Data
{
    public static class SeedGuides
    {
        public static void SeedHjalmar(this ModelBuilder modelBuilder)
        {
            // Guides with competences
            modelBuilder.Entity<Guide>().HasData(
            new Guide
            {
                Id = new Guid("00000000-0000-0000-0000-000000000009"),
                Name = "Hjalmar"
            });

            //Cheetah
            modelBuilder.Entity<AnimalCompetence>().HasData(
            new AnimalCompetence
            {
                Id = new Guid("00000000-0000-0000-1000-000000000044"),
                AnimalId = new Guid("00000000-0000-0000-0000-100000000000"),
                GuideId = new Guid("00000000-0000-0000-0000-000000000009")
            });

            //Okapi
            modelBuilder.Entity<AnimalCompetence>().HasData(
            new AnimalCompetence
            {
                Id = new Guid("00000000-0000-0000-1000-000000000045"),
                AnimalId = new Guid("00000000-0000-0000-0000-010000000000"),
                GuideId = new Guid("00000000-0000-0000-0000-000000000009")
            });
            // Bald Eagle
            modelBuilder.Entity<AnimalCompetence>().HasData(
            new AnimalCompetence
            {
                Id = new Guid("00000000-0000-0000-1000-000000000046"),
                AnimalId = new Guid("00000000-0000-0000-0000-300000000000"),
                GuideId = new Guid("00000000-0000-0000-0000-000000000009")
            });


        }



            public static void SeedNisse(this ModelBuilder modelBuilder)
            {
                // Guides with competences
                modelBuilder.Entity<Guide>().HasData(
                new Guide
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000099"),
                    Name = "Nisse"
                });

            // Electric Eel
                modelBuilder.Entity<AnimalCompetence>().HasData(
                new AnimalCompetence
                {
                    Id = new Guid("00000000-0000-0000-1000-000000000030"),
                    AnimalId = new Guid("00000000-0000-0000-0000-000000000100"),
                    GuideId = new Guid("00000000-0000-0000-0000-000000000099")
                });

            // Moray Eel
            modelBuilder.Entity<AnimalCompetence>().HasData(
                new AnimalCompetence
                {
                    Id = new Guid("00000000-0000-0000-1000-000000000031"),
                    AnimalId = new Guid("00000000-0000-0000-0000-020000000000"),
                    GuideId = new Guid("00000000-0000-0000-0000-000000000099")
                });

            // BaldEagle
            modelBuilder.Entity<AnimalCompetence>().HasData(
                 new AnimalCompetence
                 {
                     Id = new Guid("00000000-0000-0000-1000-000000000032"),
                     AnimalId = new Guid("00000000-0000-0000-0000-300000000000"),
                     GuideId = new Guid("00000000-0000-0000-0000-000000000099")
                 });
            }
        }
}

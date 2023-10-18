using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Domain.Models.Zoo;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Air;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Land;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Water;
using BVZ.BVZ.Domain.Models.Zoo.Animals.ValueTypes;
using BVZ.BVZ.Domain.Models.Zoo.Guides;
using Microsoft.EntityFrameworkCore;

namespace BVZ.BVZ.Infrastructure.Data
{
    public static class SeedData
    {
        public static void SeedAllData(this ModelBuilder modelBuilder)
        {

            //Land
            modelBuilder.Entity<Cheetah>().HasData(
             new Cheetah
             {
                 Id = new Guid("00000000-0000-0000-0000-100000000000"),
                 AnimalName = "Cheetah",
                 Specie = Specie.Mammal,
                 DailyVisits = 0,
                 Speed = 70
             });
            modelBuilder.Entity<Okapi>().HasData(
           new Okapi
           {
               Id = new Guid("00000000-0000-0000-0000-010000000000"),
               AnimalName = "Okapi",
               Specie = Specie.Mammal,
               DailyVisits = 0,
               Speed = 10
           });

            modelBuilder.Entity<Ozelot>().HasData(
          new Ozelot
          {
              Id = new Guid("00000000-0000-0000-0000-001000000000"),
              AnimalName = "Ozelot",
              Specie = Specie.Mammal,
              DailyVisits = 0,
              Speed = 30
          });


            //Water
            modelBuilder.Entity<ElectricEel>().HasData(
         new ElectricEel
         {
             Id = new Guid("00000000-0000-0000-0000-200000000000"),
             AnimalName = "Electric Eel",
             Specie = Specie.Fish,
             DailyVisits = 0,
             DivingDepth = 120
         });

            modelBuilder.Entity<MorayEel>().HasData(
         new MorayEel
         {
             Id = new Guid("00000000-0000-0000-0000-020000000000"),
             AnimalName = "Moray Eel",
             Specie = Specie.Fish,
             DailyVisits = 0,
             DivingDepth = 79
         });


            //Air
            modelBuilder.Entity<BaldEagle>().HasData(
         new BaldEagle
         {
             Id = new Guid("00000000-0000-0000-0000-300000000000"),
             AnimalName = "Bald Eagle",
             Specie = Specie.Bird,
             DailyVisits = 0,
             Wingspan = 1.4
         });
            modelBuilder.Entity<NorwegianBlueParrot>().HasData(
       new NorwegianBlueParrot
       {
           Id = new Guid("00000000-0000-0000-0000-030000000000"),
           AnimalName = "Norwegian Blue Parrot",
           Specie = Specie.Bird,
           DailyVisits = 0,
           CanSpeak = true,
           FeatherColor = "Green"
       });


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
                AnimalId = new Guid("00000000-0000-0000-0000-200000000000"),
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

            //BaldEagle
            modelBuilder.Entity<AnimalCompetence>().HasData(
                 new AnimalCompetence
                 {
                     Id = new Guid("00000000-0000-0000-1000-000000000032"),
                     AnimalId = new Guid("00000000-0000-0000-0000-300000000000"),
                     GuideId = new Guid("00000000-0000-0000-0000-000000000099")
                 });

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
                 TourName = "Djungel-Expeditionen",
                 Description = "Se djungelns mäktigaste djur..",
                 DailyBookingCount = 0,
                 GuideId = new Guid("00000000-0000-0000-0000-000000000009"),
             });

            modelBuilder.Entity<Tour>().HasData(
             new Tour
             {
                 Id = new Guid("00000000-0000-0000-0000-444400000000"),
                 TourName = "Aqua-expedition",
                 Description = "Se havets vidunder!",
                 DailyBookingCount = 0,
                 GuideId = new Guid("00000000-0000-0000-0000-000000000099"),
             });
        }
    
    }
}

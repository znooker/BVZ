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

        // HJALMAR
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

            // Ozelot
            modelBuilder.Entity<AnimalCompetence>().HasData(
            new AnimalCompetence
            {
                Id = new Guid("00000000-0000-0000-1000-000002050046"),
                AnimalId = new Guid("00000000-0000-0000-0000-001000000000"),
                GuideId = new Guid("00000000-0000-0000-0000-000000000009")
            });


        // NISSE
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
        
        // RONNY
        modelBuilder.Entity<Guide>().HasData(
        new Guide
        {
            Id = new Guid("00000000-0000-0000-0000-000700100099"),
            Name = "Ronny"
        });

            // Ozelot
            modelBuilder.Entity<AnimalCompetence>().HasData(
            new AnimalCompetence
            {
                Id = new Guid("00000000-1002-0000-1040-000000000030"),
                AnimalId = new Guid("00000000-0000-0000-0000-001000000000"),
                GuideId = new Guid("00000000-0000-0000-0000-000700100099")
            });

            // Norwegian Blue Parrot
            modelBuilder.Entity<AnimalCompetence>().HasData(
                new AnimalCompetence
                {
                    Id = new Guid("00000000-0000-0040-1030-000000000031"),
                    AnimalId = new Guid("00000000-0000-0000-0000-030000000000"),
                    GuideId = new Guid("00000000-0000-0000-0000-000700100099")
                });
            //BaldEagle
            modelBuilder.Entity<AnimalCompetence>().HasData(
                 new AnimalCompetence
                 {
                     Id = new Guid("05043020-0000-0000-1000-000000000032"),
                     AnimalId = new Guid("00000000-0000-0000-0000-300000000000"),
                     GuideId = new Guid("00000000-0000-0000-0000-000700100099")
                 });

        // Seed start-day object
        modelBuilder.Entity<ZooDay>().HasData(
            new ZooDay
            {
                Id = new Guid("00000000-0000-0000-0000-123000000000"),
                TodaysDate = DateTime.Now,
                Archived = false,
            });

            //Hjalmars guidade tur
            modelBuilder.Entity<Tour>().HasData(
             new Tour
             {
                 Id = new Guid("00000000-0000-0000-0000-444000000000"),
                 TourName = "Djungel-Expeditionen",
                 Description = "Se djungelns mäktigaste djur..",
                 GuideId = new Guid("00000000-0000-0000-0000-000000000009"),
             });

                    modelBuilder.Entity<ZooTour>().HasData(
                     new ZooTour
                     {
                         Id = new Guid("00000000-0000-0000-0000-999000000000"),
                         ZooDayId = new Guid("00000000-0000-0000-0000-123000000000"),
                         TourID = new Guid("00000000-0000-0000-0000-444000000000"),
                         IsMorningTour = true,
                         DateOfTour = DateTime.Now
                    });

                    modelBuilder.Entity<ZooTour>().HasData(
                     new ZooTour
                     {
                         Id = new Guid("00000000-0000-1000-0000-899000000000"),
                         ZooDayId = new Guid("00000000-0000-0000-0000-123000000000"),
                         TourID = new Guid("00000000-0000-0000-0000-444000000000"),
                         IsMorningTour = false,
                         DateOfTour = DateTime.Now
                     });


            //Nisses guidade tur
            modelBuilder.Entity<Tour>().HasData(
             new Tour
             {
                 Id = new Guid("00000000-0000-0000-0000-444400000000"),
                 TourName = "Aqua-expedition",
                 Description = "Se havets vidunder.. Obs, det sker på egen risk då redan åtskilliga besökare skadats av dom livsfarliga elektriska undervattensbestarna.",
                 GuideId = new Guid("00000000-0000-0000-0000-000000000099"),
             });
                    modelBuilder.Entity<ZooTour>().HasData(
                        new ZooTour
                        {
                            Id = new Guid("00000000-0000-0000-0000-999070000000"),
                            ZooDayId = new Guid("00000000-0000-0000-0000-123000000000"),
                            TourID = new Guid("00000000-0000-0000-0000-444400000000"),
                            IsMorningTour = true,
                            DateOfTour = DateTime.Now
                        });

                    modelBuilder.Entity<ZooTour>().HasData(
                        new ZooTour
                        {
                            Id = new Guid("00000000-0000-0000-0000-999070000600"),
                            ZooDayId = new Guid("00000000-0000-0000-0000-123000000000"),
                            TourID = new Guid("00000000-0000-0000-0000-444400000000"),
                            IsMorningTour = false,
                            DateOfTour = DateTime.Now
                        });

            //Ronnys guidade tur
            modelBuilder.Entity<Tour>().HasData(
             new Tour
             {
                 Id = new Guid("00000000-0000-0000-0060-444405030000"),
                 TourName = "Flygande vidunder och en liten överraskning",
                 Description = "En rasslande upplevelse bland trädens toppar. Följ med in i vindlande raviner och höga alptoppar, på jakt efter den gäckande örnen. Har vi tur får vi se, eller höra, den fåniga norska blåa papegojan. Sedan, en liten överraskning..",
                 GuideId = new Guid("00000000-0000-0000-0000-000700100099"),
             });

                modelBuilder.Entity<ZooTour>().HasData(
                    new ZooTour
                    {
                        Id = new Guid("00000080-9090-0909-0000-999070000000"),
                        ZooDayId = new Guid("00000000-0000-0000-0000-123000000000"),
                        TourID = new Guid("00000000-0000-0000-0060-444405030000"),
                        IsMorningTour = true,
                        DateOfTour = DateTime.Now
                    });

                modelBuilder.Entity<ZooTour>().HasData(
                    new ZooTour
                    {
                        Id = new Guid("00000000-0023-5070-0000-999070000600"),
                        ZooDayId = new Guid("00000000-0000-0000-0000-123000000000"),
                        TourID = new Guid("00000000-0000-0000-0060-444405030000"),
                        IsMorningTour = false,
                        DateOfTour = DateTime.Now
                    });
        }
    }
}

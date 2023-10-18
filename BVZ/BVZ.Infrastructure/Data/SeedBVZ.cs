using BVZ.BVZ.Domain.Models.Zoo.Animals;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Air;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Land;
using BVZ.BVZ.Domain.Models.Zoo.Animals.ValueTypes;
using BVZ.BVZ.Domain.Models.Zoo.Guides;
using Microsoft.EntityFrameworkCore;

namespace BVZ.BVZ.Infrastructure.Data
{
    public static class SeedBVZ
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cheetah>().HasData(
             new Cheetah
             {
                 Id = new Guid("00000000-0000-0000-0000-000000000100"),
                 Name = "Karl",
                 AnimalName = "Geopard",
                 Specie = Specie.Mammal,
                 DailyVisits = 0,
                 Speed = 70,

        });

            modelBuilder.Entity<Guide>().HasData(
            new Guide
            {
                Id = new Guid("00000000-0000-0000-0000-000000000045"),
                Name = "Hjalmar"
            });

            modelBuilder.Entity<AnimalCompetence>().HasData(
            new AnimalCompetence
            {
                Id = new Guid("00000000-0000-0000-1000-000000000045"),
                AnimalId = new Guid("00000000-0000-0000-0000-000000000100"),
                GuideId = new Guid("00000000-0000-0000-0000-000000000045")
            });

        }
    }
}
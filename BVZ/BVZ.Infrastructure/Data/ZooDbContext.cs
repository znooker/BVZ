using BVZ.BVZ.Domain.Models.Zoo.Animals;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Species;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Air;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Land;
using BVZ.BVZ.Domain.Models.Zoo.Animals.ValueTypes;
using BVZ.BVZ.Domain.Models.Zoo.Guides;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BVZ.BVZ.Infrastructure.Data
{
    public class ZooDbContext : DbContext
    {
        public ZooDbContext(DbContextOptions<ZooDbContext> options)
           : base(options)
        {
        }
        public DbSet<Animal> Animals { get; set; } = null!;

        public DbSet<Guide> Guides { get; set; } = null!;
        public DbSet<AnimalCompetence> AnimalCompetences { get; set; } = null!;

        public DbSet<ZooDay> ZooDays { get; set; } = null!;
        public DbSet<AnimalVisit> AnimalVisits { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Seed();

            builder.Entity<Animal>()
                .ToTable("Animals")
                .HasDiscriminator<string>("AnimalType")
                .HasValue<BaldEagle>("BaldEagle")
                .HasValue<Cheetah>("Cheetah")
                .HasValue<NorwegianBlueParrot>("NorwegianBlueParrot");


            // AIR-related entetites
            builder.Entity<AirHabitat>()
                .ToTable("Animals")
                .HasDiscriminator<string>("AnimalType")
                .HasValue<BaldEagle>("BaldEagle")
                .HasValue<NorwegianBlueParrot>("NorwegianBlueParrot");

            builder.Entity<BaldEagle>()
                .ToTable("Animals")
                .HasBaseType<AirHabitat>();

            builder.Entity<NorwegianBlueParrot>()
             .ToTable("Animals")
             .HasBaseType<AirHabitat>();

            // Land-related entetites
            builder.Entity<LandHabitat>()
               .ToTable("Animals")
               .HasDiscriminator<string>("AnimalType")
               .HasValue<Cheetah>("Cheetah");

            builder.Entity<Cheetah>()
             .ToTable("Animals")
             .HasBaseType<LandHabitat>();

        }
    }
}
       

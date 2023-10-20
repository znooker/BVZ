using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Domain.Models.Zoo;
using BVZ.BVZ.Domain.Models.Zoo.Animals;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Species;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Air;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Land;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Water;
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
        public DbSet<Ozelot> Ozelots { get; set; } = null!;
        public DbSet<Guide> Guides { get; set; } = null!;
        public DbSet<AnimalCompetence> AnimalCompetences { get; set; } = null!;

        public DbSet<ZooDay> ZooDays { get; set; } = null!;
        public DbSet<AnimalVisit> AnimalVisits { get; set; } = null!;

        public DbSet<Visitor> Visitors { get; set; } = null!;
        public DbSet<TourParticipant> TourParticipants { get; set; } = null!;
        public DbSet<Tour> Tours { get; set; } = null!;
        public DbSet<ZooTour> ZooTours { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("your_connection_string_here");
            }

            optionsBuilder.EnableSensitiveDataLogging(); 
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.SeedAllData();
;


            builder.Entity<Animal>()
                .ToTable("Animals")
                .HasDiscriminator<string>("AnimalType")
                .HasValue<BaldEagle>("BaldEagle")
                .HasValue<NorwegianBlueParrot>("NorwegianBlueParrot")
                .HasValue<Cheetah>("Cheetah")
                .HasValue<Ozelot>("Ozelot")
                .HasValue<Okapi>("Okapi")
                .HasValue<ElectricEel>("ElectricEel")
                .HasValue<MorayEel>("MorayEel");


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
               .HasValue<Cheetah>("Cheetah")
               .HasValue<Ozelot>("Ozelot")
               .HasValue<Okapi>("Okapi");

            builder.Entity<Cheetah>()
             .ToTable("Animals")
             .HasBaseType<LandHabitat>();

            builder.Entity<Ozelot>()
            .ToTable("Animals")
            .HasBaseType<LandHabitat>();

            builder.Entity<Okapi>()
            .ToTable("Animals")
            .HasBaseType<LandHabitat>();


            // Water-related entetites
            builder.Entity<WaterHabitat>()
               .ToTable("Animals")
               .HasDiscriminator<string>("AnimalType")
               .HasValue<ElectricEel>("ElectricEel")
               .HasValue<MorayEel>("MorayEel");

            builder.Entity<ElectricEel>()
             .ToTable("Animals")
             .HasBaseType<WaterHabitat>();

            builder.Entity<MorayEel>()
            .ToTable("Animals")
            .HasBaseType<WaterHabitat>();

        }
    }
}
       

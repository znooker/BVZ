﻿// <auto-generated />
using System;
using BVZ.BVZ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BVZ.Migrations
{
    [DbContext(typeof(ZooDbContext))]
    [Migration("20231018140203_visitor")]
    partial class visitor
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Visitors.Tour", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GuideId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NrOfParticipants")
                        .HasColumnType("int");

                    b.Property<bool>("TourCompleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("TourDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TourName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ZooDayId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GuideId");

                    b.HasIndex("ZooDayId");

                    b.ToTable("Tour");
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Visitors.TourParticipant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TourID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VisitorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TourID");

                    b.HasIndex("VisitorId");

                    b.ToTable("TourParticipant");
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Visitors.Visitor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VisitorCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Visitor");
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Animals.Animal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnimalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnimalType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DailyVisits")
                        .HasColumnType("int");

                    b.Property<int>("Specie")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Animals", (string)null);

                    b.HasDiscriminator<string>("AnimalType").HasValue("Animal");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Animals.AnimalVisit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AnimalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("VisitDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ZooDayId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("ZooDayId");

                    b.ToTable("AnimalVisits");
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Animals.ZooDay", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<DateTime>("TodaysDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ZooDays");
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Guides.AnimalCompetence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AnimalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GuideId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("GuideId");

                    b.ToTable("AnimalCompetences");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-1000-000000000045"),
                            AnimalId = new Guid("00000000-0000-0000-0000-000000000100"),
                            GuideId = new Guid("00000000-0000-0000-0000-000000000045")
                        });
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Guides.Guide", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Guides");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000045"),
                            Name = "Hjalmar"
                        });
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats.AirHabitat", b =>
                {
                    b.HasBaseType("BVZ.BVZ.Domain.Models.Zoo.Animals.Animal");

                    b.Property<double>("MaxAltitude")
                        .HasColumnType("float");

                    b.ToTable("Animals", (string)null);

                    b.HasDiscriminator().HasValue("AirHabitat");
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats.LandHabitat", b =>
                {
                    b.HasBaseType("BVZ.BVZ.Domain.Models.Zoo.Animals.Animal");

                    b.Property<double>("Speed")
                        .HasColumnType("float");

                    b.ToTable("Animals", (string)null);

                    b.HasDiscriminator().HasValue("LandHabitat");
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats.WaterHabitat", b =>
                {
                    b.HasBaseType("BVZ.BVZ.Domain.Models.Zoo.Animals.Animal");

                    b.Property<double>("DivingDepth")
                        .HasColumnType("float");

                    b.ToTable("Animals", (string)null);

                    b.HasDiscriminator().HasValue("WaterHabitat");
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Air.BaldEagle", b =>
                {
                    b.HasBaseType("BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats.AirHabitat");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Wingspan")
                        .HasColumnType("float");

                    b.ToTable("Animals", (string)null);

                    b.HasDiscriminator().HasValue("BaldEagle");
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Air.NorwegianBlueParrot", b =>
                {
                    b.HasBaseType("BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats.AirHabitat");

                    b.Property<bool>("CanSpeak")
                        .HasColumnType("bit");

                    b.Property<string>("FeatherColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Animals", null, t =>
                        {
                            t.Property("Name")
                                .HasColumnName("NorwegianBlueParrot_Name");
                        });

                    b.HasDiscriminator().HasValue("NorwegianBlueParrot");
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Land.Cheetah", b =>
                {
                    b.HasBaseType("BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats.LandHabitat");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Animals", null, t =>
                        {
                            t.Property("Name")
                                .HasColumnName("Cheetah_Name");
                        });

                    b.HasDiscriminator().HasValue("Cheetah");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000100"),
                            AnimalName = "Geopard",
                            DailyVisits = 0,
                            Specie = 0,
                            Speed = 70.0,
                            Name = "Karl"
                        });
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Land.Okapi", b =>
                {
                    b.HasBaseType("BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats.LandHabitat");

                    b.ToTable("Animals", (string)null);

                    b.HasDiscriminator().HasValue("Okapi");
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Land.Ozelot", b =>
                {
                    b.HasBaseType("BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats.LandHabitat");

                    b.ToTable("Animals", (string)null);

                    b.HasDiscriminator().HasValue("Ozelot");
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Water.ElectricEel", b =>
                {
                    b.HasBaseType("BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats.WaterHabitat");

                    b.ToTable("Animals", (string)null);

                    b.HasDiscriminator().HasValue("ElectricEel");
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Water.MorayEel", b =>
                {
                    b.HasBaseType("BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats.WaterHabitat");

                    b.ToTable("Animals", (string)null);

                    b.HasDiscriminator().HasValue("MorayEel");
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Visitors.Tour", b =>
                {
                    b.HasOne("BVZ.BVZ.Domain.Models.Zoo.Guides.Guide", "Guide")
                        .WithMany()
                        .HasForeignKey("GuideId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BVZ.BVZ.Domain.Models.Zoo.Animals.ZooDay", "ZooDay")
                        .WithMany("DailyTours")
                        .HasForeignKey("ZooDayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guide");

                    b.Navigation("ZooDay");
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Visitors.TourParticipant", b =>
                {
                    b.HasOne("BVZ.BVZ.Domain.Models.Visitors.Tour", "Tour")
                        .WithMany("TourParticipants")
                        .HasForeignKey("TourID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BVZ.BVZ.Domain.Models.Visitors.Visitor", "Visitor")
                        .WithMany("TourParticipants")
                        .HasForeignKey("VisitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tour");

                    b.Navigation("Visitor");
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Animals.AnimalVisit", b =>
                {
                    b.HasOne("BVZ.BVZ.Domain.Models.Zoo.Animals.Animal", "Animal")
                        .WithMany("AnimalVisits")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BVZ.BVZ.Domain.Models.Zoo.Animals.ZooDay", "ZooDay")
                        .WithMany("AnimalVisits")
                        .HasForeignKey("ZooDayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("ZooDay");
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Guides.AnimalCompetence", b =>
                {
                    b.HasOne("BVZ.BVZ.Domain.Models.Zoo.Animals.Animal", "Animal")
                        .WithMany("AnimalCompentencies")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BVZ.BVZ.Domain.Models.Zoo.Guides.Guide", "Guide")
                        .WithMany("GuideCompetences")
                        .HasForeignKey("GuideId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Guide");
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Visitors.Tour", b =>
                {
                    b.Navigation("TourParticipants");
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Visitors.Visitor", b =>
                {
                    b.Navigation("TourParticipants");
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Animals.Animal", b =>
                {
                    b.Navigation("AnimalCompentencies");

                    b.Navigation("AnimalVisits");
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Animals.ZooDay", b =>
                {
                    b.Navigation("AnimalVisits");

                    b.Navigation("DailyTours");
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Guides.Guide", b =>
                {
                    b.Navigation("GuideCompetences");
                });
#pragma warning restore 612, 618
        }
    }
}

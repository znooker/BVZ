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
    [Migration("20231023110929_SoftDelete")]
    partial class SoftDelete
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

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<bool>("TourCompleted")
                        .HasColumnType("bit");

                    b.Property<string>("TourName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GuideId");

                    b.ToTable("Tours");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-444000000000"),
                            Description = "Se djungelns mäktigaste djur..",
                            GuideId = new Guid("00000000-0000-0000-0000-000000000009"),
                            IsArchived = false,
                            TourCompleted = false,
                            TourName = "Djungel-Expeditionen"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-444400000000"),
                            Description = "Se havets vidunder.. Obs, det sker på egen risk då redan åtskilliga besökare skadats av dom livsfarliga elektriska undervattensbestarna.",
                            GuideId = new Guid("00000000-0000-0000-0000-000000000099"),
                            IsArchived = false,
                            TourCompleted = false,
                            TourName = "Aqua-expedition"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0060-444405030000"),
                            Description = "En rasslande upplevelse bland trädens toppar. Följ med in i vindlande raviner och höga alptoppar, på jakt efter den gäckande örnen. Har vi tur får vi se, eller höra, den fåniga norska blåa papegojan. Sedan, en liten överraskning..",
                            GuideId = new Guid("00000000-0000-0000-0000-000700100099"),
                            IsArchived = false,
                            TourCompleted = false,
                            TourName = "Flygande vidunder och en liten överraskning"
                        });
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Visitors.TourParticipant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TourID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TourSession")
                        .HasColumnType("int");

                    b.Property<DateTime>("VisitDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("VisitorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TourID");

                    b.HasIndex("VisitorId");

                    b.ToTable("TourParticipants");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-999000000000"),
                            TourID = new Guid("00000000-0000-0000-0060-444405030000"),
                            TourSession = 1,
                            VisitDate = new DateTime(2023, 10, 22, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9498),
                            VisitorId = new Guid("00000000-0000-0000-0000-999000000000")
                        },
                        new
                        {
                            Id = new Guid("00002040-8888-0000-0000-999000000000"),
                            TourID = new Guid("00000000-0000-0000-0060-444405030000"),
                            TourSession = 1,
                            VisitDate = new DateTime(2023, 10, 22, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9528),
                            VisitorId = new Guid("00700500-2340-0000-0000-999002000000")
                        });
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Visitors.Visitor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<DateTime>("TicketDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Visitors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-999000000000"),
                            Alias = "Mikael",
                            IsArchived = false,
                            TicketDate = new DateTime(2023, 10, 22, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9478)
                        },
                        new
                        {
                            Id = new Guid("00700500-2340-0000-0000-999002000000"),
                            Alias = "Hans",
                            IsArchived = false,
                            TicketDate = new DateTime(2023, 10, 22, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9514)
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-999030000900"),
                            Alias = "Raul",
                            IsArchived = false,
                            TicketDate = new DateTime(2023, 10, 22, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9543)
                        },
                        new
                        {
                            Id = new Guid("00005000-0000-0300-0000-999000076000"),
                            Alias = "Lena",
                            IsArchived = false,
                            TicketDate = new DateTime(2023, 10, 22, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9557)
                        });
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Visitors.ZooTour", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfTour")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsMorningTour")
                        .HasColumnType("bit");

                    b.Property<int>("NrOfParticipants")
                        .HasColumnType("int");

                    b.Property<Guid>("TourID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ZooDayId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TourID");

                    b.HasIndex("ZooDayId");

                    b.ToTable("ZooTours");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-999000000000"),
                            DateOfTour = new DateTime(2023, 10, 23, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9092),
                            IsMorningTour = true,
                            NrOfParticipants = 0,
                            TourID = new Guid("00000000-0000-0000-0000-444000000000"),
                            ZooDayId = new Guid("00000000-0000-0000-0000-123000000000")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-1000-0000-899000000000"),
                            DateOfTour = new DateTime(2023, 10, 23, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9108),
                            IsMorningTour = false,
                            NrOfParticipants = 0,
                            TourID = new Guid("00000000-0000-0000-0000-444000000000"),
                            ZooDayId = new Guid("00000000-0000-0000-0000-123000000000")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-999070000000"),
                            DateOfTour = new DateTime(2023, 10, 23, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9133),
                            IsMorningTour = true,
                            NrOfParticipants = 0,
                            TourID = new Guid("00000000-0000-0000-0000-444400000000"),
                            ZooDayId = new Guid("00000000-0000-0000-0000-123000000000")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-999070000600"),
                            DateOfTour = new DateTime(2023, 10, 23, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9146),
                            IsMorningTour = false,
                            NrOfParticipants = 0,
                            TourID = new Guid("00000000-0000-0000-0000-444400000000"),
                            ZooDayId = new Guid("00000000-0000-0000-0000-123000000000")
                        },
                        new
                        {
                            Id = new Guid("00000080-9090-0909-0000-999070000000"),
                            DateOfTour = new DateTime(2023, 10, 23, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9169),
                            IsMorningTour = true,
                            NrOfParticipants = 0,
                            TourID = new Guid("00000000-0000-0000-0060-444405030000"),
                            ZooDayId = new Guid("00000000-0000-0000-0000-123000000000")
                        },
                        new
                        {
                            Id = new Guid("00000000-0023-5070-0000-999070000600"),
                            DateOfTour = new DateTime(2023, 10, 23, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9315),
                            IsMorningTour = false,
                            NrOfParticipants = 0,
                            TourID = new Guid("00000000-0000-0000-0060-444405030000"),
                            ZooDayId = new Guid("00000000-0000-0000-0000-123000000000")
                        },
                        new
                        {
                            Id = new Guid("00240600-0800-0200-0000-999000000000"),
                            DateOfTour = new DateTime(2023, 10, 22, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9386),
                            IsMorningTour = true,
                            NrOfParticipants = 0,
                            TourID = new Guid("00000000-0000-0000-0000-444000000000"),
                            ZooDayId = new Guid("00000000-0000-0000-0350-123000964000")
                        },
                        new
                        {
                            Id = new Guid("11241100-0000-1000-0000-899000000000"),
                            DateOfTour = new DateTime(2023, 10, 22, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9402),
                            IsMorningTour = false,
                            NrOfParticipants = 0,
                            TourID = new Guid("00000000-0000-0000-0000-444000000000"),
                            ZooDayId = new Guid("00000000-0000-0000-0350-123000964000")
                        },
                        new
                        {
                            Id = new Guid("11303450-0000-0000-0000-999070000000"),
                            DateOfTour = new DateTime(2023, 10, 22, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9415),
                            IsMorningTour = true,
                            NrOfParticipants = 0,
                            TourID = new Guid("00000000-0000-0000-0000-444400000000"),
                            ZooDayId = new Guid("00000000-0000-0000-0350-123000964000")
                        },
                        new
                        {
                            Id = new Guid("11303451-0000-0000-0000-999070000600"),
                            DateOfTour = new DateTime(2023, 10, 22, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9429),
                            IsMorningTour = false,
                            NrOfParticipants = 0,
                            TourID = new Guid("00000000-0000-0000-0000-444400000000"),
                            ZooDayId = new Guid("00000000-0000-0000-0350-123000964000")
                        },
                        new
                        {
                            Id = new Guid("00000080-9090-0909-0090-192070300400"),
                            DateOfTour = new DateTime(2023, 10, 22, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9442),
                            IsMorningTour = true,
                            NrOfParticipants = 0,
                            TourID = new Guid("00000000-0000-0000-0060-444405030000"),
                            ZooDayId = new Guid("00000000-0000-0000-0350-123000964000")
                        },
                        new
                        {
                            Id = new Guid("00000000-0023-5070-0000-994073020600"),
                            DateOfTour = new DateTime(2023, 10, 22, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9454),
                            IsMorningTour = false,
                            NrOfParticipants = 2,
                            TourID = new Guid("00000000-0000-0000-0060-444405030000"),
                            ZooDayId = new Guid("00000000-0000-0000-0350-123000964000")
                        });
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

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

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

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.ToTable("AnimalVisits");
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
                            Id = new Guid("00000000-0000-0000-1000-000000000044"),
                            AnimalId = new Guid("00000000-0000-0000-0000-100000000000"),
                            GuideId = new Guid("00000000-0000-0000-0000-000000000009")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-1000-000000000045"),
                            AnimalId = new Guid("00000000-0000-0000-0000-010000000000"),
                            GuideId = new Guid("00000000-0000-0000-0000-000000000009")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-1000-000002050046"),
                            AnimalId = new Guid("00000000-0000-0000-0000-001000000000"),
                            GuideId = new Guid("00000000-0000-0000-0000-000000000009")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-1000-000000000030"),
                            AnimalId = new Guid("00000000-0000-0000-0000-200000000000"),
                            GuideId = new Guid("00000000-0000-0000-0000-000000000099")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-1000-000000000031"),
                            AnimalId = new Guid("00000000-0000-0000-0000-020000000000"),
                            GuideId = new Guid("00000000-0000-0000-0000-000000000099")
                        },
                        new
                        {
                            Id = new Guid("00000000-1002-0000-1040-000000000030"),
                            AnimalId = new Guid("00000000-0000-0000-0000-001000000000"),
                            GuideId = new Guid("00000000-0000-0000-0000-000700100099")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0040-1030-000000000031"),
                            AnimalId = new Guid("00000000-0000-0000-0000-030000000000"),
                            GuideId = new Guid("00000000-0000-0000-0000-000700100099")
                        },
                        new
                        {
                            Id = new Guid("05043020-0000-0000-1000-000000000032"),
                            AnimalId = new Guid("00000000-0000-0000-0000-300000000000"),
                            GuideId = new Guid("00000000-0000-0000-0000-000700100099")
                        });
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Guides.Guide", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUnavailable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Guides");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000009"),
                            IsArchived = false,
                            IsUnavailable = false,
                            Name = "Hjalmar"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000099"),
                            IsArchived = false,
                            IsUnavailable = false,
                            Name = "Nisse"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000700100099"),
                            IsArchived = false,
                            IsUnavailable = false,
                            Name = "Ronny"
                        });
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.ZooDay", b =>
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-123000000000"),
                            Archived = false,
                            TodaysDate = new DateTime(2023, 10, 23, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(8918)
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0350-123000964000"),
                            Archived = false,
                            TodaysDate = new DateTime(2023, 10, 22, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9331)
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

                    b.Property<double>("Wingspan")
                        .HasColumnType("float");

                    b.ToTable("Animals", (string)null);

                    b.HasDiscriminator().HasValue("BaldEagle");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-300000000000"),
                            AnimalName = "Bald Eagle",
                            DailyVisits = 0,
                            IsArchived = false,
                            Specie = 2,
                            MaxAltitude = 0.0,
                            Wingspan = 1.3999999999999999
                        });
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Air.NorwegianBlueParrot", b =>
                {
                    b.HasBaseType("BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats.AirHabitat");

                    b.Property<bool>("CanSpeak")
                        .HasColumnType("bit");

                    b.Property<string>("FeatherColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Animals", (string)null);

                    b.HasDiscriminator().HasValue("NorwegianBlueParrot");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-030000000000"),
                            AnimalName = "Norwegian Blue Parrot",
                            DailyVisits = 0,
                            IsArchived = false,
                            Specie = 2,
                            MaxAltitude = 0.0,
                            CanSpeak = true,
                            FeatherColor = "Green"
                        });
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Land.Cheetah", b =>
                {
                    b.HasBaseType("BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats.LandHabitat");

                    b.ToTable("Animals", (string)null);

                    b.HasDiscriminator().HasValue("Cheetah");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-100000000000"),
                            AnimalName = "Cheetah",
                            DailyVisits = 0,
                            IsArchived = false,
                            Specie = 0,
                            Speed = 70.0
                        });
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Land.Okapi", b =>
                {
                    b.HasBaseType("BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats.LandHabitat");

                    b.ToTable("Animals", (string)null);

                    b.HasDiscriminator().HasValue("Okapi");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-010000000000"),
                            AnimalName = "Okapi",
                            DailyVisits = 0,
                            IsArchived = false,
                            Specie = 0,
                            Speed = 10.0
                        });
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Land.Ozelot", b =>
                {
                    b.HasBaseType("BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats.LandHabitat");

                    b.ToTable("Animals", (string)null);

                    b.HasDiscriminator().HasValue("Ozelot");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-001000000000"),
                            AnimalName = "Ozelot",
                            DailyVisits = 0,
                            IsArchived = false,
                            Specie = 0,
                            Speed = 30.0
                        });
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Water.ElectricEel", b =>
                {
                    b.HasBaseType("BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats.WaterHabitat");

                    b.ToTable("Animals", (string)null);

                    b.HasDiscriminator().HasValue("ElectricEel");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-200000000000"),
                            AnimalName = "Electric Eel",
                            DailyVisits = 0,
                            IsArchived = false,
                            Specie = 1,
                            DivingDepth = 120.0
                        });
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Water.MorayEel", b =>
                {
                    b.HasBaseType("BVZ.BVZ.Domain.Models.Zoo.Animals.Habitats.WaterHabitat");

                    b.ToTable("Animals", (string)null);

                    b.HasDiscriminator().HasValue("MorayEel");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-020000000000"),
                            AnimalName = "Moray Eel",
                            DailyVisits = 0,
                            IsArchived = false,
                            Specie = 1,
                            DivingDepth = 79.0
                        });
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Visitors.Tour", b =>
                {
                    b.HasOne("BVZ.BVZ.Domain.Models.Zoo.Guides.Guide", "Guide")
                        .WithMany("Tours")
                        .HasForeignKey("GuideId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guide");
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

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Visitors.ZooTour", b =>
                {
                    b.HasOne("BVZ.BVZ.Domain.Models.Visitors.Tour", "Tour")
                        .WithMany("ZooTours")
                        .HasForeignKey("TourID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BVZ.BVZ.Domain.Models.Zoo.ZooDay", "ZooDay")
                        .WithMany("ZooTours")
                        .HasForeignKey("ZooDayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tour");

                    b.Navigation("ZooDay");
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Animals.AnimalVisit", b =>
                {
                    b.HasOne("BVZ.BVZ.Domain.Models.Zoo.Animals.Animal", "Animal")
                        .WithMany("AnimalVisits")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Guides.AnimalCompetence", b =>
                {
                    b.HasOne("BVZ.BVZ.Domain.Models.Zoo.Animals.Animal", "Animal")
                        .WithMany("AnimalCompentencies")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BVZ.BVZ.Domain.Models.Zoo.Guides.Guide", "Guide")
                        .WithMany("AnimalCompetences")
                        .HasForeignKey("GuideId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Guide");
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Visitors.Tour", b =>
                {
                    b.Navigation("TourParticipants");

                    b.Navigation("ZooTours");
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

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.Guides.Guide", b =>
                {
                    b.Navigation("AnimalCompetences");

                    b.Navigation("Tours");
                });

            modelBuilder.Entity("BVZ.BVZ.Domain.Models.Zoo.ZooDay", b =>
                {
                    b.Navigation("ZooTours");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wyklad10.Models;

namespace cw11.Migrations
{
    [DbContext(typeof(HospitalDbContext))]
    partial class HospitalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("cw11.Models.Doctor", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Email")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("FirstName")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("IdDoctor")
                    .HasColumnType("int");

                b.Property<string>("LastName")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("Doctor");

                b.HasData(
                    new
                    {
                        Id = 1,
                        Email = "123@g.com",
                        FirstName = "Jan",
                        IdDoctor = 1,
                        LastName = "Kowalski"
                    },
                    new
                    {
                        Id = 2,
                        Email = "1243@g.com",
                        FirstName = "Kuba",
                        IdDoctor = 2,
                        LastName = "Nowak"
                    },
                    new
                    {
                        Id = 3,
                        Email = "1235@g.com",
                        FirstName = "Kan",
                        IdDoctor = 3,
                        LastName = "Bowal"
                    });
            });

            modelBuilder.Entity("cw11.Models.Medicament", b =>
            {
                b.Property<int>("IdMedicament")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Description")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Type")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("IdMedicament");

                b.ToTable("Medicament");

                b.HasData(
                    new
                    {
                        IdMedicament = 1,
                        Description = "desc1",
                        Name = "medi1",
                        Type = "m1"
                    },
                    new
                    {
                        IdMedicament = 2,
                        Description = "desc2",
                        Name = "medi2",
                        Type = "m2"
                    },
                    new
                    {
                        IdMedicament = 3,
                        Description = "desc3",
                        Name = "medi3",
                        Type = "m3"
                    });
            });

            modelBuilder.Entity("cw11.Models.Patient", b =>
            {
                b.Property<int>("IdPatient")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<DateTime>("Birthdate")
                    .HasColumnType("datetime2");

                b.Property<string>("FirstName")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("LastName")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("IdPatient");

                b.ToTable("Patient");

                b.HasData(
                    new
                    {
                        IdPatient = 1,
                        Birthdate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        FirstName = "Cezary",
                        LastName = "Boguszewski"
                    },
                    new
                    {
                        IdPatient = 2,
                        Birthdate = new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        FirstName = "Konrad",
                        LastName = "Sztynks"
                    },
                    new
                    {
                        IdPatient = 3,
                        Birthdate = new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        FirstName = "Piotr",
                        LastName = "Gago"
                    });
            });

            modelBuilder.Entity("cw11.Models.Prescription", b =>
            {
                b.Property<int>("IdPrescription")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<DateTime>("Date")
                    .HasColumnType("datetime2");

                b.Property<DateTime>("DueDate")
                    .HasColumnType("datetime2");

                b.Property<int>("IdDoctor")
                    .HasColumnType("int");

                b.Property<int>("IdPatient")
                    .HasColumnType("int");

                b.HasKey("IdPrescription");

                b.ToTable("Prescription");

                b.HasData(
                    new
                    {
                        IdPrescription = 1,
                        Date = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        DueDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        IdDoctor = 0,
                        IdPatient = 0
                    },
                    new
                    {
                        IdPrescription = 2,
                        Date = new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        DueDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        IdDoctor = 1,
                        IdPatient = 1
                    },
                    new
                    {
                        IdPrescription = 3,
                        Date = new DateTime(2011, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        DueDate = new DateTime(2021, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        IdDoctor = 2,
                        IdPatient = 2
                    });
            });

            modelBuilder.Entity("cw11.Models.PrescriptionMedicament", b =>
            {
                b.Property<int>("IdMedicament")
                    .HasColumnType("int");

                b.Property<int>("IdPrescription")
                    .HasColumnType("int");

                b.Property<string>("Details")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("Dose")
                    .HasColumnType("int");

                b.HasKey("IdMedicament", "IdPrescription");

                b.ToTable("Prescription_Medicament");

                b.HasData(
                    new
                    {
                        IdMedicament = 1,
                        IdPrescription = 1,
                        Details = "d1",
                        Dose = 50
                    },
                    new
                    {
                        IdMedicament = 2,
                        IdPrescription = 2,
                        Details = "d2",
                        Dose = 40
                    },
                    new
                    {
                        IdMedicament = 3,
                        IdPrescription = 3,
                        Details = "d3",
                        Dose = 10
                    });
            });
#pragma warning restore 612, 618
        }
    }
}
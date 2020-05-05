﻿// <auto-generated />
using E_LOGO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace E_LOGO.Migrations
{
    [DbContext(typeof(E_LOGOContext))]
    [Migration("20200429095754_Patients")]
    partial class Patients
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("E_LOGO.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Diagnostique")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LastTaskDone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Results")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("SpeechTherapistID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpeechTherapistID");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Diagnostique = "dyslexique",
                            Fullname = "Pablo cousu",
                            LastTaskDone = "no one",
                            Results = "not defined",
                            SpeechTherapistID = 2
                        },
                        new
                        {
                            Id = 2,
                            Diagnostique = "dyslexique",
                            Fullname = "Maido kapo",
                            LastTaskDone = "5B",
                            Results = "not defined",
                            SpeechTherapistID = 1
                        },
                        new
                        {
                            Id = 3,
                            Diagnostique = "aphasique",
                            Fullname = "Jojo tousk",
                            LastTaskDone = "17A",
                            Results = "0/20",
                            SpeechTherapistID = 1
                        });
                });

            modelBuilder.Entity("E_LOGO.Models.SpeechTherapist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<string>("Firstname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Lastname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("SpeechTherapists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "matilde",
                            Firstname = "Matilde",
                            Lastname = "Gravano",
                            Password = "matilde"
                        },
                        new
                        {
                            Id = 2,
                            Email = "pelagie",
                            Firstname = "Pélagie",
                            Lastname = "Lacroix",
                            Password = "pelagie"
                        });
                });

            modelBuilder.Entity("E_LOGO.Models.Patient", b =>
                {
                    b.HasOne("E_LOGO.Models.SpeechTherapist", "SpeechTherapist")
                        .WithMany("Patients")
                        .HasForeignKey("SpeechTherapistID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

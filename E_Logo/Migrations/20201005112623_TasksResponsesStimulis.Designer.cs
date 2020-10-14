﻿// <auto-generated />
using System;
using E_LOGO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace E_LOGO.Migrations
{
    [DbContext(typeof(E_LOGOContext))]
    [Migration("20201005112623_TasksResponsesStimulis")]
    partial class TasksResponsesStimulis
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
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("LastTaskDone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("SpeechTherapistID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Fullname")
                        .IsUnique();

                    b.HasIndex("SpeechTherapistID");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Diagnostique = "dyslexique",
                            Fullname = "Pablo cousu",
                            LastTaskDone = "no one",
                            SpeechTherapistID = 2
                        },
                        new
                        {
                            Id = 2,
                            Diagnostique = "dyslexique",
                            Fullname = "Maido kapo",
                            LastTaskDone = "5B",
                            SpeechTherapistID = 1
                        },
                        new
                        {
                            Id = 3,
                            Diagnostique = "aphasique",
                            Fullname = "Jojo tousk",
                            LastTaskDone = "17A",
                            SpeechTherapistID = 1
                        },
                        new
                        {
                            Id = 4,
                            Diagnostique = "dyslexique",
                            Fullname = "Charline Dupont",
                            LastTaskDone = "5B",
                            SpeechTherapistID = 1
                        },
                        new
                        {
                            Id = 5,
                            Diagnostique = "dyslexique",
                            Fullname = "Benoit Blanc",
                            LastTaskDone = "5B",
                            SpeechTherapistID = 2
                        },
                        new
                        {
                            Id = 6,
                            Diagnostique = "dyslexique",
                            Fullname = "Maxime Gros",
                            LastTaskDone = "5B",
                            SpeechTherapistID = 2
                        },
                        new
                        {
                            Id = 7,
                            Diagnostique = "dyslexique",
                            Fullname = "Elodie Filou",
                            LastTaskDone = "5B",
                            SpeechTherapistID = 1
                        },
                        new
                        {
                            Id = 8,
                            Diagnostique = "dyslexique",
                            Fullname = "Julie Desprez",
                            LastTaskDone = "5B",
                            SpeechTherapistID = 2
                        });
                });

            modelBuilder.Entity("E_LOGO.Models.Response", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Choice")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("StimuliID")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("StimuliID");

                    b.ToTable("Responses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Choice = "a",
                            StimuliID = 1,
                            Type = 1
                        },
                        new
                        {
                            Id = 2,
                            Choice = "h",
                            StimuliID = 1,
                            Type = 1
                        },
                        new
                        {
                            Id = 3,
                            Choice = "d",
                            StimuliID = 2,
                            Type = 1
                        },
                        new
                        {
                            Id = 4,
                            Choice = "b",
                            StimuliID = 2,
                            Type = 1
                        },
                        new
                        {
                            Id = 5,
                            Choice = "o",
                            StimuliID = 3,
                            Type = 1
                        },
                        new
                        {
                            Id = 6,
                            Choice = "c",
                            StimuliID = 3,
                            Type = 1
                        },
                        new
                        {
                            Id = 7,
                            Choice = "n",
                            StimuliID = 4,
                            Type = 1
                        },
                        new
                        {
                            Id = 8,
                            Choice = "d",
                            StimuliID = 4,
                            Type = 1
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
                            Lastname = "Campos",
                            Password = "pelagie"
                        });
                });

            modelBuilder.Entity("E_LOGO.Models.Stimuli", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("TaskID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("TaskID");

                    b.ToTable("Stimulis");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "A",
                            TaskID = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "B",
                            TaskID = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "C",
                            TaskID = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "D",
                            TaskID = 1
                        });
                });

            modelBuilder.Entity("E_LOGO.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Tâche 1: appariement de lettres"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Tâche 2 : Lecture de mots"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tâche 3: Dénomination des objets"
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

            modelBuilder.Entity("E_LOGO.Models.Response", b =>
                {
                    b.HasOne("E_LOGO.Models.Patient", null)
                        .WithMany("Responses")
                        .HasForeignKey("PatientId");

                    b.HasOne("E_LOGO.Models.Stimuli", "Stimuli")
                        .WithMany("Responses")
                        .HasForeignKey("StimuliID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("E_LOGO.Models.Stimuli", b =>
                {
                    b.HasOne("E_LOGO.Models.Task", "Task")
                        .WithMany("Stimulis")
                        .HasForeignKey("TaskID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

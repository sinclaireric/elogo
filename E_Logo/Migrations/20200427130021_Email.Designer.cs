// <auto-generated />
using E_LOGO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace E_LOGO.Migrations
{
    [DbContext(typeof(E_LOGOContext))]
    [Migration("20200427130021_Email")]
    partial class Email
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

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
#pragma warning restore 612, 618
        }
    }
}

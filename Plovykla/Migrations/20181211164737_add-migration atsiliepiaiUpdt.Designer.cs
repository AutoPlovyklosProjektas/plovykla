﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Plovykla.Models;

namespace Plovykla.Migrations
{
    [DbContext(typeof(SistemosCtx))]
    [Migration("20181211164737_add-migration atsiliepiaiUpdt")]
    partial class addmigrationatsiliepiaiUpdt
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Plovykla.Models.Atsiliepimai", b =>
                {
                    b.Property<int>("atsiliepimoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("atsiliepimas");

                    b.Property<int>("paslaugosId");

                    b.Property<int>("vartotojoId");

                    b.HasKey("atsiliepimoId");

                    b.HasIndex("paslaugosId");

                    b.HasIndex("vartotojoId");

                    b.ToTable("Atsiliepimais");
                });

            modelBuilder.Entity("Plovykla.Models.Baudos", b =>
                {
                    b.Property<int>("baudosId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("baudosAprasymas");

                    b.Property<DateTime>("data");

                    b.Property<double>("nuostolis");

                    b.Property<int>("uzsakymoId");

                    b.Property<int>("vartotojoId");

                    b.HasKey("baudosId");

                    b.HasIndex("uzsakymoId");

                    b.HasIndex("vartotojoId");

                    b.ToTable("Baudos");
                });

            modelBuilder.Entity("Plovykla.Models.Busenos", b =>
                {
                    b.Property<int>("busenosId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("busena");

                    b.HasKey("busenosId");

                    b.ToTable("Busenos");
                });

            modelBuilder.Entity("Plovykla.Models.Kategorija", b =>
                {
                    b.Property<int>("kategorijosId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("kategorijosPavadinimas");

                    b.HasKey("kategorijosId");

                    b.ToTable("Kategorijas");
                });

            modelBuilder.Entity("Plovykla.Models.Medziagos", b =>
                {
                    b.Property<int>("medziagosId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("medziaga");

                    b.HasKey("medziagosId");

                    b.ToTable("Medziagos");
                });

            modelBuilder.Entity("Plovykla.Models.Paslauga", b =>
                {
                    b.Property<int>("paslaugosId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("paslaugosAprasymas");

                    b.Property<double>("paslaugosKaina");

                    b.Property<string>("paslaugosPavadinimas");

                    b.HasKey("paslaugosId");

                    b.ToTable("Paslaugas");
                });

            modelBuilder.Entity("Plovykla.Models.Trukumai", b =>
                {
                    b.Property<int>("trukumoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("medziagosId");

                    b.HasKey("trukumoId");

                    b.HasIndex("medziagosId");

                    b.ToTable("Trukumais");
                });

            modelBuilder.Entity("Plovykla.Models.Uzsakymas", b =>
                {
                    b.Property<int>("uzsakymoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("busenosId");

                    b.Property<int?>("darbuotojoId");

                    b.Property<int?>("klientoId");

                    b.Property<int>("paslaugosId");

                    b.Property<double>("uzsakymoKaina");

                    b.Property<DateTime>("uzsakymo_Data");

                    b.HasKey("uzsakymoId");

                    b.HasIndex("busenosId");

                    b.HasIndex("darbuotojoId");

                    b.HasIndex("klientoId");

                    b.HasIndex("paslaugosId");

                    b.ToTable("Uzsakymas");
                });

            modelBuilder.Entity("Plovykla.Models.Vartotojai", b =>
                {
                    b.Property<int>("vartotojoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email");

                    b.Property<int>("kategorijosId");

                    b.Property<string>("password");

                    b.Property<string>("pavarde");

                    b.Property<string>("username");

                    b.Property<string>("vardas");

                    b.HasKey("vartotojoId");

                    b.HasIndex("kategorijosId");

                    b.ToTable("Vartotojais");
                });

            modelBuilder.Entity("Plovykla.Models.Atsiliepimai", b =>
                {
                    b.HasOne("Plovykla.Models.Paslauga", "Paslauga")
                        .WithMany("Atsiliepimas")
                        .HasForeignKey("paslaugosId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Plovykla.Models.Vartotojai", "Vartotojai")
                        .WithMany("Atsiliepimai")
                        .HasForeignKey("vartotojoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Plovykla.Models.Baudos", b =>
                {
                    b.HasOne("Plovykla.Models.Uzsakymas", "Uzsakymas")
                        .WithMany("Baudos")
                        .HasForeignKey("uzsakymoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Plovykla.Models.Vartotojai", "Vartotojai")
                        .WithMany("Baudos")
                        .HasForeignKey("vartotojoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Plovykla.Models.Trukumai", b =>
                {
                    b.HasOne("Plovykla.Models.Medziagos", "Medziagos")
                        .WithMany("Trukumai")
                        .HasForeignKey("medziagosId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Plovykla.Models.Uzsakymas", b =>
                {
                    b.HasOne("Plovykla.Models.Busenos", "Busenos")
                        .WithMany("Uzsakymas")
                        .HasForeignKey("busenosId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Plovykla.Models.Vartotojai", "Vartotojai")
                        .WithMany("Uzsakymas")
                        .HasForeignKey("darbuotojoId");

                    b.HasOne("Plovykla.Models.Vartotojai", "Klientai")
                        .WithMany("Klientai")
                        .HasForeignKey("klientoId");

                    b.HasOne("Plovykla.Models.Paslauga", "Paslauga")
                        .WithMany("Uzsakymas")
                        .HasForeignKey("paslaugosId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Plovykla.Models.Vartotojai", b =>
                {
                    b.HasOne("Plovykla.Models.Kategorija", "Kategorija")
                        .WithMany("Vartotojai")
                        .HasForeignKey("kategorijosId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

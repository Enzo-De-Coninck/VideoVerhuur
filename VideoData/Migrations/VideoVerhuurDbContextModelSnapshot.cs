﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VideoData.Models;

#nullable disable

namespace VideoData.Migrations
{
    [DbContext(typeof(VideoVerhuurDbContext))]
    partial class VideoVerhuurDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VideoData.Models.Film", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FilmId"));

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("InVoorraad")
                        .HasColumnType("int");

                    b.Property<decimal>("Prijs")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotaalVerhuurd")
                        .HasColumnType("int");

                    b.Property<int>("UitVoorraad")
                        .HasColumnType("int");

                    b.Property<int?>("VerhuringVerhuurId")
                        .HasColumnType("int");

                    b.HasKey("FilmId");

                    b.HasIndex("GenreId");

                    b.HasIndex("VerhuringVerhuurId");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("VideoData.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<string>("GenreNaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("VideoData.Models.Klant", b =>
                {
                    b.Property<int>("KlantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KlantId"));

                    b.Property<DateTime>("DatumLid")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gemeente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HuurAantal")
                        .HasColumnType("int");

                    b.Property<string>("KlantStat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Lidgeld")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Straat_Nr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KlantId");

                    b.ToTable("Klanten");
                });

            modelBuilder.Entity("VideoData.Models.Verhuring", b =>
                {
                    b.Property<int>("VerhuurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VerhuurId"));

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("KlantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("VerhuurDatum")
                        .HasColumnType("datetime2");

                    b.HasKey("VerhuurId");

                    b.HasIndex("KlantId");

                    b.ToTable("Verhuringen");
                });

            modelBuilder.Entity("VideoData.Models.Film", b =>
                {
                    b.HasOne("VideoData.Models.Genre", "Genre")
                        .WithMany("Films")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VideoData.Models.Verhuring", "Verhuring")
                        .WithMany("Films")
                        .HasForeignKey("VerhuringVerhuurId");

                    b.Navigation("Genre");

                    b.Navigation("Verhuring");
                });

            modelBuilder.Entity("VideoData.Models.Verhuring", b =>
                {
                    b.HasOne("VideoData.Models.Klant", "Klant")
                        .WithMany("Verhuring")
                        .HasForeignKey("KlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Klant");
                });

            modelBuilder.Entity("VideoData.Models.Genre", b =>
                {
                    b.Navigation("Films");
                });

            modelBuilder.Entity("VideoData.Models.Klant", b =>
                {
                    b.Navigation("Verhuring");
                });

            modelBuilder.Entity("VideoData.Models.Verhuring", b =>
                {
                    b.Navigation("Films");
                });
#pragma warning restore 612, 618
        }
    }
}

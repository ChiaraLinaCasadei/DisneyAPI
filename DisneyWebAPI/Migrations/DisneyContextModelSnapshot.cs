﻿// <auto-generated />
using System;
using DisneyWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DisneyWebAPI.Migrations
{
    [DbContext(typeof(DisneyContext))]
    partial class DisneyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CharacterMultimedia", b =>
                {
                    b.Property<Guid>("FilmographyMultId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MultCastCharacterID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FilmographyMultId", "MultCastCharacterID");

                    b.HasIndex("MultCastCharacterID");

                    b.ToTable("CharacterMultimedia");
                });

            modelBuilder.Entity("DisneyWebAPI.Models.Character", b =>
                {
                    b.Property<Guid>("CharacterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CharacterAge")
                        .HasColumnType("int");

                    b.Property<string>("CharacterImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CharacterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CharacterStory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CharacterWeight")
                        .HasColumnType("int");

                    b.HasKey("CharacterID");

                    b.ToTable("characters");
                });

            modelBuilder.Entity("DisneyWebAPI.Models.Genre", b =>
                {
                    b.Property<Guid>("GenreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GenreImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GenreName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreID");

                    b.ToTable("genres");
                });

            modelBuilder.Entity("DisneyWebAPI.Models.Multimedia", b =>
                {
                    b.Property<Guid>("MultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GenreID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("MultDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MultImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MultRate")
                        .HasColumnType("int");

                    b.Property<string>("MultTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MultId");

                    b.HasIndex("GenreID");

                    b.ToTable("multimedias");
                });

            modelBuilder.Entity("CharacterMultimedia", b =>
                {
                    b.HasOne("DisneyWebAPI.Models.Multimedia", null)
                        .WithMany()
                        .HasForeignKey("FilmographyMultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DisneyWebAPI.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("MultCastCharacterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DisneyWebAPI.Models.Multimedia", b =>
                {
                    b.HasOne("DisneyWebAPI.Models.Genre", null)
                        .WithMany("GenreMult")
                        .HasForeignKey("GenreID");
                });

            modelBuilder.Entity("DisneyWebAPI.Models.Genre", b =>
                {
                    b.Navigation("GenreMult");
                });
#pragma warning restore 612, 618
        }
    }
}

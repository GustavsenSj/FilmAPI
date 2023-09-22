﻿// <auto-generated />
using System;
using FilmAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FilmAPI.Migrations
{
    [DbContext(typeof(FilmDbContext))]
    partial class FilmDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.Property<int>("CharactersId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("CharactersId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("CharacterMovie");
                });

            modelBuilder.Entity("FilmAPI.Data.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Alias = "Luke Skywalker",
                            FullName = "Mark Hamill",
                            Gender = "Male"
                        },
                        new
                        {
                            Id = 2,
                            Alias = "Anakin Skywalker",
                            FullName = "Hayde Christensen",
                            Gender = "Male"
                        });
                });

            modelBuilder.Entity("FilmAPI.Data.Models.Franchise", b =>
                {
                    b.Property<int>("FranchiseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FranchiseId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FranchiseId");

                    b.ToTable("Franchises");
                });

            modelBuilder.Entity("FilmAPI.Data.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<int?>("FranchiseId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(201)
                        .HasColumnType("nvarchar(201)");

                    b.Property<string>("Trailer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseId");

                    b.ToTable("Movie");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Director = "George Lucas",
                            Genre = "SciFi",
                            ReleaseYear = 1997,
                            Title = "Star Wars"
                        },
                        new
                        {
                            Id = 2,
                            Director = "George Lucas",
                            Genre = "SciFi",
                            ReleaseYear = 1980,
                            Title = "The Empire Strikes Back"
                        },
                        new
                        {
                            Id = 3,
                            Director = "George Lucas",
                            Genre = "SciFi",
                            ReleaseYear = 1983,
                            Title = "Return of the Jedi"
                        },
                        new
                        {
                            Id = 4,
                            Director = "George Lucas",
                            Genre = "SciFi",
                            ReleaseYear = 1999,
                            Title = "The Phantom Menace"
                        },
                        new
                        {
                            Id = 5,
                            Director = "George Lucas",
                            Genre = "SciFi",
                            ReleaseYear = 2002,
                            Title = "Attack of the Clones"
                        },
                        new
                        {
                            Id = 6,
                            Director = "George Lucas",
                            Genre = "SciFi",
                            ReleaseYear = 2005,
                            Title = "Revenge of the Sith"
                        });
                });

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.HasOne("FilmAPI.Data.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FilmAPI.Data.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmAPI.Data.Models.Movie", b =>
                {
                    b.HasOne("FilmAPI.Data.Models.Franchise", "Franchise")
                        .WithMany("Movies")
                        .HasForeignKey("FranchiseId");

                    b.Navigation("Franchise");
                });

            modelBuilder.Entity("FilmAPI.Data.Models.Franchise", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}

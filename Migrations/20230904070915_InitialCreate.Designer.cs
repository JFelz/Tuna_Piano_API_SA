﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Tuna_Piano;

#nullable disable

namespace Tuna_Piano.Migrations
{
    [DbContext(typeof(Tuna_PianoDbContext))]
    [Migration("20230904070915_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Tuna_Piano.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 23,
                            Bio = "Mehdi Benjelloun, known by his stage name Petit Biscuit, is a French-Moroccan DJ and music producer. The 23-year-old French-Moroccan producer is known for his distinctive style, forged through combining acoustic elements, electronic production, and vocal manipulations.",
                            Name = "Petit Biscuit"
                        },
                        new
                        {
                            Id = 2,
                            Age = 19,
                            Bio = "DVRST - a young musician from Russia who writes music in different directions and tries to create his own sound by mixing styles.",
                            Name = "DVRST"
                        },
                        new
                        {
                            Id = 3,
                            Age = 21,
                            Bio = "Bethel Music is an American music label and worship movement from Redding, California, originating out of Bethel Church where they started making music in 2001.",
                            Name = "Bethel"
                        },
                        new
                        {
                            Id = 4,
                            Age = 67,
                            Bio = "Ludovico Maria Enrico Einaudi OMRI is an Italian pianist and composer. Trained at the Conservatorio Verdi in Milan, Einaudi began his career as a classical composer.",
                            Name = "Ludivico Enaudi"
                        });
                });

            modelBuilder.Entity("Tuna_Piano.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Chillwave"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Indie"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Synthwave"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Phonk"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Rock"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Latin"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Christian"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Classical"
                        });
                });

            modelBuilder.Entity("Tuna_Piano.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Album")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ArtistId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("length")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Album = "You",
                            ArtistId = 1,
                            Title = "You",
                            length = 180
                        },
                        new
                        {
                            Id = 2,
                            Album = "Close Eyes EP",
                            ArtistId = 2,
                            Title = "Close Eyes",
                            length = 180
                        },
                        new
                        {
                            Id = 3,
                            Album = "Victory",
                            ArtistId = 3,
                            Title = "Goodness of God",
                            length = 180
                        },
                        new
                        {
                            Id = 4,
                            Album = "Una Mattina",
                            ArtistId = 4,
                            Title = "Nuvole Bianche",
                            length = 180
                        },
                        new
                        {
                            Id = 5,
                            Album = "Una Mattina",
                            ArtistId = 4,
                            Title = "Ora",
                            length = 180
                        },
                        new
                        {
                            Id = 6,
                            Album = "Victory",
                            ArtistId = 3,
                            Title = "Stand in Your Love",
                            length = 180
                        });
                });

            modelBuilder.Entity("Tuna_Piano.Models.SongGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.Property<int>("SongId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("SongsGenres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreId = 1,
                            SongId = 1
                        },
                        new
                        {
                            Id = 2,
                            GenreId = 4,
                            SongId = 2
                        },
                        new
                        {
                            Id = 3,
                            GenreId = 7,
                            SongId = 3
                        },
                        new
                        {
                            Id = 4,
                            GenreId = 8,
                            SongId = 4
                        },
                        new
                        {
                            Id = 5,
                            GenreId = 8,
                            SongId = 5
                        },
                        new
                        {
                            Id = 6,
                            GenreId = 7,
                            SongId = 6
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

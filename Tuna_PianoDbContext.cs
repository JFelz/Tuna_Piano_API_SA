using Microsoft.EntityFrameworkCore;
using Tuna_Piano.Models;

namespace Tuna_Piano
{
    public class Tuna_PianoDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<SongGenre> SongsGenres { get; set;}

        public Tuna_PianoDbContext(DbContextOptions<Tuna_PianoDbContext> context) : base(context)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().HasData( new Song[]
            {
                new Song { Id = 1, Title ="You", ArtistId = 1 ,Album = "You", length = 180},
                new Song { Id = 2, Title ="Chill", ArtistId = 2 ,Album = "Strange", length = 180},
                new Song { Id = 3, Title ="", ArtistId = 3 ,Album = "", length = 180},
                new Song { Id = 4, Title ="", ArtistId = 1 ,Album = "", length = 180},
                new Song { Id = 5, Title ="", ArtistId = 1 ,Album = "", length = 180},
                new Song { Id = 6, Title ="", ArtistId = 1 ,Album = "", length = 180},
            });
            modelBuilder.Entity<Artist>().HasData(new Artist[]
            {
                new Artist {Id = 1, Name = "Petit Biscuit", Age = 29, Bio = ""},
                new Artist {Id = 2, Name = "Hensonn", Age = 29, Bio = ""},
                new Artist {Id = 3, Name = "Bethel", Age = 29, Bio = ""},
                new Artist {Id = 4, Name = "", Age = 29, Bio = ""},
            });
            modelBuilder.Entity<Genre>().HasData(new Genre[]
            {
                new Genre {Id = 1, Description = "Chillwave"},
                new Genre {Id = 2, Description = "Indie"},
                new Genre {Id = 3, Description = "Synthwave"},
                new Genre {Id = 4, Description = "Phonk"},
                new Genre {Id = 5, Description = "Rock"},
                new Genre {Id = 6, Description = "Christian"},
                new Genre {Id = 7, Description = "Latin"},
                new Genre {Id = 8, Description = "Classical"},

            });
            modelBuilder.Entity<SongGenre>().HasData(new SongGenre[]
            {
                new SongGenre { Id = 1, SongId = 1, GenreId = 1 },
                new SongGenre { Id = 2, SongId = 2, GenreId = 4 },
                new SongGenre { Id = 3, SongId = 1, GenreId = 1 },
                new SongGenre { Id = 4, SongId = 1, GenreId = 1 },
                new SongGenre { Id = 5, SongId = 1, GenreId = 1 },
                new SongGenre { Id = 6, SongId = 1, GenreId = 1 },

            });
        }
    }
}

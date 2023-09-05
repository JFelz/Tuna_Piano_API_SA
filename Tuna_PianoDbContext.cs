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
                new Song { Id = 2, Title ="Close Eyes", ArtistId = 2 ,Album = "Close Eyes EP", length = 180},
                new Song { Id = 3, Title ="Goodness of God", ArtistId = 3 ,Album = "Victory", length = 180},
                new Song { Id = 4, Title ="Nuvole Bianche", ArtistId = 4 ,Album = "Una Mattina", length = 180},
                new Song { Id = 5, Title ="Ora", ArtistId = 4 ,Album = "Una Mattina", length = 180},
                new Song { Id = 6, Title ="Stand in Your Love", ArtistId = 3 , Album = "Victory", length = 180},
            });
            modelBuilder.Entity<Artist>().HasData(new Artist[]
            {
                new Artist {Id = 1, Name = "Petit Biscuit", Age = 23, Bio = "Mehdi Benjelloun, known by his stage name Petit Biscuit, is a French-Moroccan DJ and music producer. The 23-year-old French-Moroccan producer is known for his distinctive style, forged through combining acoustic elements, electronic production, and vocal manipulations."},
                new Artist {Id = 2, Name = "DVRST", Age = 19, Bio = "DVRST - a young musician from Russia who writes music in different directions and tries to create his own sound by mixing styles."},
                new Artist {Id = 3, Name = "Bethel", Age = 21, Bio = "Bethel Music is an American music label and worship movement from Redding, California, originating out of Bethel Church where they started making music in 2001."},
                new Artist {Id = 4, Name = "Ludivico Enaudi", Age = 67, Bio = "Ludovico Maria Enrico Einaudi OMRI is an Italian pianist and composer. Trained at the Conservatorio Verdi in Milan, Einaudi began his career as a classical composer."},
            });
            modelBuilder.Entity<Genre>().HasData(new Genre[]
            {
                new Genre {Id = 1, Description = "Chillwave"},
                new Genre {Id = 2, Description = "Indie"},
                new Genre {Id = 3, Description = "Synthwave"},
                new Genre {Id = 4, Description = "Phonk"},
                new Genre {Id = 5, Description = "Rock"},
                new Genre {Id = 6, Description = "Latin"},
                new Genre {Id = 7, Description = "Christian"},
                new Genre {Id = 8, Description = "Classical"},

            });
            modelBuilder.Entity<SongGenre>().HasData(new SongGenre[]
            {
                new SongGenre { Id = 1, SongId = 1, GenreId = 1 },
                new SongGenre { Id = 2, SongId = 2, GenreId = 4 },
                new SongGenre { Id = 3, SongId = 3, GenreId = 7 },
                new SongGenre { Id = 4, SongId = 4, GenreId = 8 },
                new SongGenre { Id = 5, SongId = 5, GenreId = 8 },
                new SongGenre { Id = 6, SongId = 6, GenreId = 7 },
            });
            modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
            {
                new UserProfile{Id = 1, UID = "YOfJwqkulPUXzojJjdnCFXwrQkw2", displayName = "Jovanni Feliz"}
            });

        }
    }
}

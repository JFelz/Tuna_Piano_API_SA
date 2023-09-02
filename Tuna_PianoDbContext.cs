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
                new Song { Id = 1, Title ="Loyal", ArtistId = 1 ,Album = "A Moment Apart", length = 180},
                new Song { Id = 1, Title ="", ArtistId = 1 ,Album = "", length = 180},
                new Song { Id = 1, Title ="", ArtistId = 1 ,Album = "", length = 180},
            });
        }
    }
}

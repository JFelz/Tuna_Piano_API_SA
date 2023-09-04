using System.ComponentModel.DataAnnotations;

namespace Tuna_Piano.Models
{
    public class SongGenre
    {
        public int Id { get; set; }
        [Required]
        public int SongId { get; set; }
        public int GenreId { get; set; }
        public Genre Genres { get; set; }
    }
}

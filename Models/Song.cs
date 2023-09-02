using System.ComponentModel.DataAnnotations;

namespace Tuna_Piano.Models
{
    public class Song
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public string Album { get; set;}
        public int length { get; set; }
    }
}

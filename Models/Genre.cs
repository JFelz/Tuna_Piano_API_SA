using System.ComponentModel.DataAnnotations;

namespace Tuna_Piano.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
    }
}

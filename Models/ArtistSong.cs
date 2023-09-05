using System;
using System.ComponentModel.DataAnnotations;
namespace Tuna_Piano.Models
{
	public class ArtistSong
	{
		
		public int Id { get; set; }
		[Required]
		public int ArtistId { get; set; }
		public Artist Artists { get; set; }
		public int SongId { get; set; }
		public Song Songs { get; set; }
	
	}
}


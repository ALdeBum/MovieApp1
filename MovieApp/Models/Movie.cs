using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        [Required]
        public string Poster { get; set; } // URL постера

        public string Description { get; set; }
    }
}

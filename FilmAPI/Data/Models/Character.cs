using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace FilmAPI.Data.Models
{
    /// <summary>
    /// The Character class is a model class that represents a character in a movie.
    /// </summary>
    public class Character
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(60)] public string FullName { get; set; } = null!;
        [StringLength(60)] public string? Alias { get; set; }
        [StringLength(15)] public string Gender { get; set; } = null!;
        public string? Picture { get; set; } // Can be nullable

        // Associated movies for character nav prop
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
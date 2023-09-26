using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace FilmAPI.Data.Models
{
    /// <summary>
    /// The Franchise class is a model class that represents a franchise of movies.
    /// </summary>
    public class Franchise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(60)] 
        public string Name { get; set; } = null!;
        public string? Description { get; set; }


        /*------------------------iT's movies realtion stuff------------------------------*/
        // nav prop for franchise's related movies
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
        /*--------------------------------------------------------------------------------*/
    }
}
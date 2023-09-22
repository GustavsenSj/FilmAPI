using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmAPI.Data.Models;

[Table(nameof(Movie))]
public class Movie
{
    public int Id { get; set; }
    [StringLength(201)] //longest movie title according to Wikipedia
    public string Title { get; set; } = null!;
    [StringLength(50)]
    public string Genre { get; set; } = null!;
    public int ReleaseYear { get; set; }
    [StringLength(70)]
    public string Director { get; set; } = null!;
    public string? Picture { get; set; }
    public string? Trailer { get; set; }

    /*---------------------It's characters relation stuff------------------------------*/
    // Nav prop for associated characters played in the movie.
    public ICollection<MovieCharacter> MovieCharacters { get; set; } = new List<MovieCharacter>();
    /*---------------------------------------------------------------------------------*/


    /*---------------------Franchise relation stuff------------------------------*/
    public int? FranchiseId { get; set; } // FK for relation with it's possible Franchsie
    public Franchise? Franchise { get; set; } // nav prop for related franchise
    /*---------------------------------------------------------------------------------*/

}
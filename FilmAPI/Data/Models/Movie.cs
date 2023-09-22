using System.ComponentModel.DataAnnotations.Schema;

namespace FilmAPI.Data.Models;

[Table(nameof(Movie))]
public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public int ReleaseYear { get; set; }
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
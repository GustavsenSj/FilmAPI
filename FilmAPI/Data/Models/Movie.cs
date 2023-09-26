using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace FilmAPI.Data.Models;

/// <summary>
/// The Movie class is a model class that represents a movie.
/// </summary>
[Table(nameof(Movie))]
public class Movie
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(201)] //longest movie title according to Wikipedia
    public string Title { get; set; } = null!;

    [StringLength(50)] public string Genre { get; set; } = null!;
    public int ReleaseYear { get; set; }
    [StringLength(70)] public string Director { get; set; } = null!;
    public string? Picture { get; set; }
    public string? Trailer { get; set; }


    // Nav prop for associated characters played in the movie.
    public ICollection<Character> Characters { get; set; } = new List<Character>();

    // FK for relation with it's possible Franchsie
    public int? FranchiseId { get; set; }

    // nav prop for related franchise
    public Franchise? Franchise { get; set; }
}
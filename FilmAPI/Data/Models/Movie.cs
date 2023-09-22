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
}
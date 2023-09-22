namespace FilmAPI.Data.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public DateTime ReleaseYear { get; set; }
    public string Director { get; set; }
    public string? Picture { get; set; }
    public string? Trailer { get; set; }
}
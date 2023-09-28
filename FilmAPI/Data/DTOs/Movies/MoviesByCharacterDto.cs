namespace FilmAPI.Data.DTOs.Movies;

/// <summary>
/// MoviesByCharacterDto is a DTO for Movie objects. To be used when a list of movies is returned for a character.
/// </summary>
public class MoviesByCharacterDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public int ReleaseYear { get; set; }
    public string Director { get; set; } = null!;
    public string? Picture { get; set; }
    public string? Trailer { get; set; }
}
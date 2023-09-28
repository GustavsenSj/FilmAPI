using FilmAPI.Data.Dtos.Characters;

namespace FilmAPI.Data.DTOs.Movies;

/// <summary>
/// MovieDto is a DTO for Movie objects.
/// </summary>
public class MovieDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Genre { get; set; } =null!;
    public int ReleaseYear { get; set; }
    public string Director { get; set; } =null!;
    public string? Picture { get; set; }
    public string? Trailer { get; set; }
    public ICollection<CharacterDto> Characters { get; set; } = null!;
}
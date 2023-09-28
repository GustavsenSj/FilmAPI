namespace FilmAPI.Data.Dtos.Characters;

/// <summary>
/// CharacterInMovieDto is a DTO for Character objects. It represents a character when displayed to the user in a movie context. 
/// </summary>
public class CharacterInMovieDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Alias { get; set; } = null!;
    public string Gender { get; set; } = null!;
    public string? Picture { get; set; }
}
namespace FilmAPI.Data.Dtos.Characters;

/// <summary>
/// CharacterNameInMovieDto is a DTO for Character objects. It is used when one only needs to display the name and alias of a character in a movie context.
/// </summary>
public class CharacterNameInMovieDto
{
    public string FullName { get; set; } = null!; 
    public string? Alias { get; set; }
}
namespace FilmAPI.Data.Dtos.Characters;

/// <summary>
/// DTO for adding/posting a character
/// </summary>
public class CharacterAddDto
{
    public string FullName { get; set; } = null!;
    public string? Alias { get; set; } 
    public string Gender { get; set; } = null!;
}
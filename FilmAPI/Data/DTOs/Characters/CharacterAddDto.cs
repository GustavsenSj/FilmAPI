#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
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
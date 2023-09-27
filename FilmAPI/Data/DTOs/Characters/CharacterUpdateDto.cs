namespace FilmAPI.Data.Dtos.Characters;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

/// <summary>
/// CharacterUpdateDto is a DTO for Character objects. It is used when one needs to update a character. 
/// </summary>
public class CharacterUpdateDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string? Alias { get; set; }
    public string? Gender { get; set; }
}
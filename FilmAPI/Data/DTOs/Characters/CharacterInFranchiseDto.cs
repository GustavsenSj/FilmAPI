namespace FilmAPI.Data.Dtos.Characters;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

/// <summary>
/// CharacterInFranchiseDto is a DTO for Character objects in the context of a Franchise.
/// </summary>
public class CharacterInFranchiseDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Alias { get; set; } = null!;
}
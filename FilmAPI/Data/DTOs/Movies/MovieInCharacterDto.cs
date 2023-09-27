#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace FilmAPI.Data.DTOs.Movies;

/// <summary>
/// MovieInCharacterDto is a DTO for Movie objects that are used in Character objects display.
/// </summary>
public class MovieInCharacterDto
{
    public string Title { get; set; } = null!;
}
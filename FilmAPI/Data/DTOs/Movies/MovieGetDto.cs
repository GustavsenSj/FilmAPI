using FilmAPI.Data.Dtos.Characters;
using FilmAPI.Data.Dtos.Franchises;
using FilmAPI.Data.Models;

namespace FilmAPI.Data.DTOs.Movies;

/// <summary>
/// This is the DTO that is used to return a movie to the client. It displays the movies info with a list of character names
/// </summary>
public class MovieGetDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public int ReleaseYear { get; set; }
    public string Director { get; set; } = null!;
    public string? Picture { get; set; }
    public string? Trailer { get; set; }

    public ICollection<CharacterNameInMovieDto> Characters { get; set; } = null!;
    public FranchiseInMovieDto? Franchise { get; set; }
}
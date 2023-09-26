namespace FilmAPI.Data.DTOs.Movies;

public class MovieGetDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public int ReleaseYear { get; set; }
    public string Director { get; set; }
    public string? Picture { get; set; }
    public string? Trailer { get; set; }
    public ICollection<CharacterInMoviesDto> Characters { get; set; }
}
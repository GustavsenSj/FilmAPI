namespace FilmAPI.Data.DTOs.Movies;

/// <summary>
/// MovieInFranchiseDto is a DTO for Movie objects when displayed in aa context of a Franchise.
/// </summary>
public class MovieInFranchiseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public int ReleaseYear { get; set; }
    public string Director { get; set; } = null!;
    public string? Picture { get; set; }
    public string? Trailer { get; set; }
}
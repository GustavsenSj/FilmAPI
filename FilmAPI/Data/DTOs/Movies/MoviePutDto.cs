using System.ComponentModel.DataAnnotations;

namespace FilmAPI.Data.DTOs.Movies;

/// <summary>
/// This is the DTO used for PUTing/updating a new movie.
/// </summary>
public class MoviePutDto
{
    public int Id { get; set; }
    [StringLength(201)] 
    public string Title { get; set; } = null!;
    [StringLength(50)] 
    public string Genre { get; set; } = null!;
   
    public int ReleaseYear { get; set; }
    
    [StringLength(70)] 
    public string Director { get; set; } = null!;
    
    public string? Picture { get; set; }
    
    public string? Trailer { get; set; }
}

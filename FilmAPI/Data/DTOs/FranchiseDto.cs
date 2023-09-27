using FilmAPI.Data.DTOs.Movies;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace FilmAPI.Data.DTOs;
/// <summary>
/// FranchiseDto is a DTO for Franchise objects. 
/// </summary>
public class FranchiseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public ICollection<MovieDto> Movies { get; set; } =null!;
}
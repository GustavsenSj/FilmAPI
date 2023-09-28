using FilmAPI.Data.DTOs.Movies;
namespace FilmAPI.Data.Dtos.Franchises;
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
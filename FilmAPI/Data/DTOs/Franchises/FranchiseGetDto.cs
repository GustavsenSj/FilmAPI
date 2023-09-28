using FilmAPI.Data.DTOs.Movies;

namespace FilmAPI.Data.Dtos.Franchises;

/// <summary>
/// A DTO for getting Franchise. Used wen getting a simple version of franchise.
/// </summary>
public class FranchiseGetDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public ICollection<MovieInCharacterDto> Movies { get; set; } =null!;
}
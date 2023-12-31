namespace FilmAPI.Data.Dtos.Franchises;
/// <summary>
/// Franchise DTO for POSTing a new Franchise
/// </summary>
public class FranchisePostDto
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}
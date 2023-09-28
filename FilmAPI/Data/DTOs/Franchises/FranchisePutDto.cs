namespace FilmAPI.Data.Dtos.Franchises;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

/// <summary>
/// FranchisePutDto is used for PUTing/updating a Franchise.
/// </summary>
public class FranchisePutDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}
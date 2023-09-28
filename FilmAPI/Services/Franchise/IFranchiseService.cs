namespace FilmAPI.Services.Franchise;

/// <summary>
/// Interface for the FranchiseService class.
/// </summary>
public interface IFranchiseService : ICrudService<Data.Models.Franchise, int>
{
    /// <summary>
    /// Add a movie to a franchise
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ICollection<Data.Models.Movie>> GetMoviesInFranchiseAsync(int id);
}
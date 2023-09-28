using FilmAPI.Data.Exceptions;

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

    /// <summary>
    /// Update the movies in a franchise
    /// </summary>
    /// <param name="id"></param>
    /// <param name="movieIds"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="EntityNotFoundException"></exception>
    Task UpdateMoviesInFranchiseAsync(int id, int[] movieIds);

    /// <summary>
    /// Get all the characters in a franchise
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<IEnumerable<Data.Models.Character>> GetCharactersInFranchiseAsync(int id);
}
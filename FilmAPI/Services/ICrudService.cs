using FilmAPI.Data.Exceptions;

namespace FilmAPI.Services;

/// <summary>
/// Interface for a service that provides CRUD operations for a type <typeparamref name="T"/> with an Id of type <typeparamref name="TId"/> 
/// </summary>
/// <typeparam name="T"> </typeparam>
/// <typeparam name="TId"></typeparam>
public interface ICrudService <T, in TId>
{
    /// <summary>
    /// Gets all the instances of <typeparamref name="T"/> in the database
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<T>> GetAllAsync();
    
    /// <summary>
    /// Gets an instance of <typeparamref name="T"/> by its Id
    /// </summary>
    /// <param name="id"> ID of entity to get</param>
    /// exception cref="ArgumentOutOfRangeException">
    /// exception cref="EntityNotFoundException">
    /// <returns></returns>
    /// <exception cref="EntityNotFoundException"></exception>
    Task<T> GetByIdAsync(TId id);
    
    /// <summary>
    /// Adds an instance of <typeparamref name="T"/> to the database
    /// </summary>
    /// <param name="t"> The instance of <typeparamref name="T"/> to add</param>
    /// <returns></returns>
    /// <exception cref="EntityNotFoundException"></exception>
    Task<T> AddAsync(T t);

    /// <summary>
    /// Updates an instance of <typeparamref name="T"/> in the database
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    /// <exception cref="EntityAlreadyExistsException"></exception>
    /// <exception cref="EntityNotFoundException"></exception>
    Task<T> UpdateAsync(T t);
    
    /// <summary>
    /// Deletes an instance of <typeparamref name="T"/> from the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="EntityNotFoundException"></exception>
    Task DeleteAsync(TId id);
}
using FilmAPI.Data.Exceptions;

namespace FilmAPI.Services;

public interface ICrudService <T, ID>
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
    Task<T> GetByIdAsync(ID id);
    
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
    /// <exception cref="EntityNotFoundException"></exception>
    Task<T> UpdateAsync(T t);
    
    /// <summary>
    /// Deletes an instance of <typeparamref name="T"/> from the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="EntityNotFoundException"></exception>
    Task DeleteAsync(ID id);
}
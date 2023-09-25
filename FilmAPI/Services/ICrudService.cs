namespace FilmAPI.Services;

public interface ICrudService <T, ID>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(ID id);
    Task<T> AddAsync(T t);
    Task<T> UpdateAsync(T t);
    Task<T> DeleteAsync(ID id);
}
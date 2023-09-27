using FilmAPI.Data.Models;

namespace FilmAPI.Services.Character
{
    public interface ICharacterService : ICrudService<Data.Models.Character, int>
    {
        Task<IEnumerable<Data.Models.Character>> GetAllAsync();
        Task<Data.Models.Character> GetByIdAsync(int id);
        Task<Data.Models.Character> AddAsync(Data.Models.Character obj);
        Task<Data.Models.Character> UpdateAsync(Data.Models.Character obj);
        Task DeleteAsync(int id);
        Task<ICollection<Data.Models.Movie>> GetCharacterInMoviesAsync(int characterId);
    }
}
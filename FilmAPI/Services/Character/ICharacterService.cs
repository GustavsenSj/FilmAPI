using FilmAPI.Data.Models;
using System.Collections.ObjectModel;

namespace FilmAPI.Services.Character
{
    public interface ICharacterService : ICrudService<Data.Models.Character, int>
    {
        Task<ICollection<Data.Models.Movie>> GetCharacterInMoviesAsync(int id);
        Task<Data.Models.Character> UpdateMoviesOfCharacterAsync(int characterId, int[] movieIds);
    }
}

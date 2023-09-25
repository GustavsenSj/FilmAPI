using FilmAPI.Data.Models;

namespace FilmAPI.Services.Movie;

public interface IMovieService: ICrudService<Data.Models.Movie, int>
{
   Task AddCharacterToMovieAsync(int movieId, int characterId);
   Task<ICollection<Character>> GetCharactersForMovieAsync(int movieId);
   Task AddFranchiseToMovieAsync(int movieId, int franchiseId);
}
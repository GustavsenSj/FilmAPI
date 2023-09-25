namespace FilmAPI.Services.Movie;

public interface IMovieService: ICrudService<Data.Models.Movie, int>
{
   Task AddCharacterToMovieAsync(int movieId, int characterId);
   Task<ICollection<Data.Models.Character>> GetCharactersForMovieAsync(int movieId);
   Task AddFranchiseToMovieAsync(int movieId, int franchiseId);
}
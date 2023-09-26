namespace FilmAPI.Services.Movie;

/// <summary>
/// Interface for the MovieService class.
/// </summary>
public interface IMovieService: ICrudService<Data.Models.Movie, int>
{
   /// <summary>
   /// Adds a character to a movie.
   /// </summary>
   /// <param name="movieId">The id of the movie to add a character to</param>
   /// <param name="characterId">The id of the character to be added</param>
   /// <returns></returns>
   Task AddCharacterToMovieAsync(int movieId, int characterId);
   
   /// <summary>
   ///  Gets all the characters for the specified movie.
   /// </summary>
   /// <param name="movieId"> The id of the movie to get the characters from</param>
   /// <returns></returns>
   Task<ICollection<Data.Models.Character>> GetCharactersForMovieAsync(int movieId);
   
   /// <summary>
   /// Adds a franchise to a movie. 
   /// </summary>
   /// <param name="movieId"> The ID of the movie to give a franchise</param>
   /// <param name="franchiseId"> The ID of the franchise to give the movie</param>
   /// <returns></returns>
   Task AddFranchiseToMovieAsync(int movieId, int franchiseId);
}
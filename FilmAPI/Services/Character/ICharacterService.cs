namespace FilmAPI.Services.Character
{
    /// <summary>
    /// Interface for the CharacterService
    /// </summary>
    public interface ICharacterService : ICrudService<Data.Models.Character, int>
    {
        /// <summary>
        /// Get all movies that a character is in
        /// </summary>
        /// <param name="characterId"></param>
        /// <returns></returns>
        Task<ICollection<Data.Models.Movie>> GetCharacterInMoviesAsync(int characterId);
        
        /// <summary>
        /// Update the movies that a character is in
        /// </summary>
        /// <param name="characterId"></param>
        /// <param name="movieIds"></param>
        /// <returns></returns>
        Task<Data.Models.Character> UpdateMoviesOfCharacterAsync(int characterId, int[] movieIds);

        /// <summary>
        /// Add a character to movie
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="characterId"></param>
        /// <returns></returns>
        Task<Data.Models.Character> AddCharacterToMovieAsync(int movieId, int characterId);
    }
}
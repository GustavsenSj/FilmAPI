namespace FilmAPI.Data.Exceptions;

/// <summary>
/// Exception to thrown when a movie is not found in the database
/// </summary>
public class MovieNotFoundException:Exception
{
    /// <summary>
    /// Exception thrown when a movie is not found in the database
    /// </summary>
    /// <param name="id"></param>
    public MovieNotFoundException(int id):base($"Movie with id {id} not found.")
    {
    }
}
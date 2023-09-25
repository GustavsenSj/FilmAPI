namespace FilmAPI.Data.Exceptions;

/// <summary>
/// Exception to thrown when a movie is not found in the database
/// </summary>
public class EntityNotFoundException:Exception
{
    /// <summary>
    /// Exception thrown when a movie is not found in the database
    /// </summary>
    /// <param name="id"></param>
    public EntityNotFoundException(int id):base($"Entity with id {id} not found.")
    {
    }
}
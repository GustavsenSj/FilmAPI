namespace FilmAPI.Data.Exceptions;

/// <summary>
/// EntityAlreadyExistsException is a base class for exceptions that are thrown when an entity already exists. 
/// </summary>
public class EntityAlreadyExistsException : Exception
{
    /// <summary>
    /// Init a new instance of <see cref="EntityAlreadyExistsException"/>
    /// </summary>
    /// <param name="entityType">Basically entity type; Character, Movie etc.</param> 
    /// <param name="entityId">Entity.Id basically.</param> 
    public EntityAlreadyExistsException(string entityType, int entityId) :
        base($"{entityType} with Id {entityId} already exists.")
    {
    }
}
namespace FilmAPI.Data.Exceptions
{
    /// <summary>
    /// EXC. for case of already existing entity
    /// </summary>
    public class EntityAlreadyExistsException: Exception
    {
        /// <summary>
        /// Init a new instance of <see cref="EntityAlreadyExistsException"/>
        /// </summary>
        /// <param name="entityType">Basically entity type; Character, Movie etc.</param> 
        /// <param name="entityId">Entity.Id basically.</param> 
        public EntityAlreadyExistsException(string entityType, int entityId):
            base($"{entityType} with Id {entityId} already exists.")
        { }
    }
}

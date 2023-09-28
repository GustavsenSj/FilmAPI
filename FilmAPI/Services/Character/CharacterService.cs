using FilmAPI.Data;
using FilmAPI.Data.Exceptions;
using FilmAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmAPI.Services.Character
{
    /// <summary>
    /// Service for the Character entity
    /// </summary>
    public class CharacterService : ICharacterService
    {
        private readonly FilmDbContext _context;
        //private readonly ICrudService<Data.Models.Character, int> _crudService;

        /// <summary>
        /// Constructor for the CharacterService
        /// </summary>
        /// <param name="context"></param>
        public CharacterService(FilmDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Data.Models.Character>> GetAllAsync()
        {
            // not sure if there should be an excpetion here since the db is already
            // seeded with sample data.
            // Eager loading, including the characters'es related movies.
            return await _context.Characters.Include(chr => chr.Movies).ToListAsync();
        }

        /// <inheritdoc />
        public async Task<Data.Models.Character> GetByIdAsync(int id)
        {
            bool characterNotNull = await _context.Characters.AnyAsync(
                chr => chr.Id == id);
            if (characterNotNull)
            {
                var character = await _context.Characters
                    .Include(chr => chr.Movies)
                    .FirstAsync(chr => chr.Id == id);
                return character;
            }
            throw new EntityNotFoundException(id);
        }

        /// <inheritdoc />
        public async Task<Data.Models.Character> AddAsync(Data.Models.Character obj)
        {
            // cana add/throw exception here for not being able to add an already-existing
            // character.
            if (!await CharacterExistsAsync(obj.Id))
            {
                await _context.Characters.AddAsync(obj);
                await _context.SaveChangesAsync();
                return obj;
            }

            throw new EntityAlreadyExistsException(nameof(obj), obj.Id);
        }

        /// <inheritdoc />
        public async Task<Data.Models.Character> UpdateAsync(Data.Models.Character obj)
        {
            bool characterNotNull = await CharacterExistsAsync(obj.Id);
            if (characterNotNull)
            {
                // Like in the lectures, force updates of related some place else
                obj.Movies.Clear();
                _context.Entry(obj).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return obj;
            }

            throw new EntityNotFoundException(obj.Id);
        }


        /// <inheritdoc />
        public async Task DeleteAsync(int id)
        {
            // Likely have to add try/catch here for triying to delete non existant character
            if (!await CharacterExistsAsync(id))
            {
                throw new EntityNotFoundException(id);
            }

            var character = await _context.Characters.FindAsync(id);

            character!.Movies.Clear();
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task<ICollection<Data.Models.Movie>> GetCharacterInMoviesAsync(int characterId)
        {
            var character = await _context.Characters
                .Include(chr => chr.Movies)
                .FirstOrDefaultAsync(chr => chr.Id == characterId);

            if (character != null)
            {
                return character.Movies.ToList();
            }

            throw new EntityNotFoundException(characterId);
        }
        
        /// <inheritdoc />
        public async Task<Data.Models.Character> UpdateMoviesOfCharacterAsync(int characterId, int[] movieIds)
        {
            if (!await CharacterExistsAsync(characterId))
            {
                throw new EntityNotFoundException(characterId);
            }
            var character = await _context.Characters.FindAsync(characterId);
            var movies = new List<Data.Models.Movie>();

            foreach (int id in movieIds)
            {
                if (!await MovieExistsAsync(id))
                {
                    throw new EntityNotFoundException(id);
                }
                movies.Add(await _context.Movies
                    .Where(mov => mov.Id == id)
                    .FirstAsync());
            }
            character!.Movies = movies;
            await _context.SaveChangesAsync();
            return character;
        }
        
        /// <inheritdoc/>
        public async Task<Data.Models.Character> AddCharacterToMovieAsync(int movieId, int characterId)
        {
            // check if the movie exists at all & also do for character exists check

            if (!await MovieExistsAsync(movieId))
            {
                throw new EntityNotFoundException(movieId);
            }

            if (!await CharacterExistsAsync(characterId))
            {
                throw new EntityNotFoundException(characterId);
            }

            // Last check of wether character is already IN the movie 
            var selectedMovie = await _context.Movies
                .Include(mov => mov.Characters)
                .FirstOrDefaultAsync(mov => mov.Id == movieId);
            if (selectedMovie.Characters.Any( chr => chr.Id == characterId))
            {
                throw new EntityAlreadyExistsException(nameof(Character), characterId);
            }

            // Add chr to d movie & save.
            var selectedCharacter = await _context.Characters
                .Include(chr => chr.Movies)
                .FirstOrDefaultAsync(chr => chr.Id == characterId);
            selectedMovie.Characters.Add(selectedCharacter);
            await _context.SaveChangesAsync();
            return selectedCharacter;

        }
        
        //HELPER METHOD
        private async Task<bool> CharacterExistsAsync(int id)
        {
            return await _context.Characters.AnyAsync(chr => chr.Id == id);
        }
        private Task<bool> MovieExistsAsync(int movieId)
        {
            return _context.Movies.AnyAsync(mov => mov.Id == movieId);
        } 

    }
}
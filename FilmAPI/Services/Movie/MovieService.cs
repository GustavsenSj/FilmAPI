using FilmAPI.Data;
using FilmAPI.Data.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace FilmAPI.Services.Movie;

/// <summary>
/// Service for Movie
/// </summary>
public class MovieService : IMovieService
{
    private readonly FilmDbContext _context;

    /// <summary>
    /// Constructor for MovieService 
    /// </summary>
    /// <param name="context"></param>
    public MovieService(FilmDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Data.Models.Movie>> GetAllAsync()
    {
        return await _context.Movies.Include(m => m.Characters).Include(m=> m.Franchise).ToListAsync();
    }


    /// <inheritdoc />
    public async Task<Data.Models.Movie> GetByIdAsync(int id)
    {
        if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));
        Data.Models.Movie movie = (await _context.Movies.Where(m => m.Id == id).Include(m=> m.Characters). FirstOrDefaultAsync() ?? null) ??
                                  throw new EntityNotFoundException(id);
        return movie;
    }

    /// <inheritdoc />
    public async Task<Data.Models.Movie> AddAsync(Data.Models.Movie obj)
    {
        if (!await MovieExistsAsync(obj.Id))
        {
            await _context.Movies.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        throw new EntityAlreadyExistsException(nameof(obj), obj.Id);
    }

    /// <inheritdoc />
    public async Task<Data.Models.Movie> UpdateAsync(Data.Models.Movie obj)
    {
        if (!await MovieExistsAsync(obj.Id))
            throw new EntityNotFoundException(obj.Id);
        obj.Characters.Clear();
        obj.Franchise = null;
        _context.Entry(obj).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return obj;
    }


    /// <inheritdoc />
    public async Task DeleteAsync(int id)
    {
        if (!await MovieExistsAsync(id))
            throw new EntityNotFoundException(id);
        var movie = await _context.Movies.FindAsync(id);

        if (movie != null)
        {
            movie.Characters.Clear();
            movie.Franchise = null;
            _context.Movies.Remove(movie);
        }

        await _context.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task UpdateCharacterInMovieAsync(int movieId, int[] charactersId)
    {
        if (movieId <= 0) throw new ArgumentOutOfRangeException(nameof(movieId));
        if (!await MovieExistsAsync(movieId))
            throw new EntityNotFoundException(movieId);

        Data.Models.Movie movie = await _context.Movies.FindAsync(movieId) ??
                                  throw new EntityNotFoundException(movieId);

        List<Data.Models.Character> characters = new List<Data.Models.Character>();
        foreach (int id in charactersId)
        {
            if (!await CharacterExists(id))
                throw new EntityNotFoundException(id);
            characters.Add((await _context.Characters.FindAsync(id))!);
        }


        movie.Characters = characters;
        await _context.SaveChangesAsync();
    }


    /// <inheritdoc />
    public async Task<ICollection<Data.Models.Character>> GetCharactersForMovieAsync(int movieId)
    {
        if (movieId <= 0) throw new ArgumentOutOfRangeException(nameof(movieId));
        if (!await MovieExistsAsync(movieId))
            throw new EntityNotFoundException(movieId);
        return await _context.Movies.Where(m => m.Id == movieId).SelectMany(m => m.Characters).ToListAsync();
    }

    /// <inheritdoc />
    public Task AddFranchiseToMovieAsync(int movieId, int franchiseId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Check if a movie exists in the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    private async Task<bool> MovieExistsAsync(object id)
    {
        return await _context.Movies.AnyAsync(e => e.Id == (int)id);
    }

    /// <summary>
    /// Check if a character exists in the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    private async Task<bool> CharacterExists(int id)
    {
        return await _context.Characters.AnyAsync(e => e.Id == id);
    }
}
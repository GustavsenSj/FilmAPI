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
        return await _context.Movies.ToListAsync();
    }


    /// <inheritdoc />
    public async Task<Data.Models.Movie> GetByIdAsync(int id)
    {
        if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));
        Data.Models.Movie movie = (await _context.Movies.Where(m => m.Id == id).FirstOrDefaultAsync() ?? null) ?? throw new EntityNotFoundException(id);
        return movie;
    }

    /// <inheritdoc />
    public async Task<Data.Models.Movie> AddAsync(Data.Models.Movie obj)
    {
        await _context.Movies.AddAsync(obj);
        await _context.SaveChangesAsync();
        return obj;
    }

    /// <inheritdoc />
    public async Task<Data.Models.Movie> UpdateAsync(Data.Models.Movie obj)
    {
        if (! await MovieExistsAsync(obj.Id))
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

    public Task AddCharacterToMovieAsync(int movieId, int characterId)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Data.Models.Character>> GetCharactersForMovieAsync(int movieId)
    {
        throw new NotImplementedException();
    }

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
}

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
    public Task<Data.Models.Movie> AddAsync(Data.Models.Movie t)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<Data.Models.Movie> UpdateAsync(Data.Models.Movie t)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<Data.Models.Movie> DeleteAsync(int id)
    {
        throw new NotImplementedException();
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
}
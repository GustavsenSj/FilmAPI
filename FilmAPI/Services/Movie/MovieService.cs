using FilmAPI.Data;
using FilmAPI.Data.Exceptions;
using FilmAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmAPI.Services.Movie;

public class MovieService : IMovieService
{
    private readonly FilmDbContext _context;

    public MovieService(FilmDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Data.Models.Movie>> GetAllAsync()
    {
        return await _context.Movies.ToListAsync();
    }

    /// <summary>
    /// Get a movie by its id
    /// Throws an exception if the movie is not found
    /// </summary>
    /// <param name="id"> id of the move to be found</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<Data.Models.Movie> GetByIdAsync(int id)
    {
        if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));
        Data.Models.Movie movie = (await _context.Movies.Where(m => m.Id == id).FirstOrDefaultAsync() ?? null) ?? throw new MovieNotFoundException(id); 
        return movie;
    }

    public Task<Data.Models.Movie> AddAsync(Data.Models.Movie t)
    {
        throw new NotImplementedException();
    }

    public Task<Data.Models.Movie> UpdateAsync(Data.Models.Movie t)
    {
        throw new NotImplementedException();
    }

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
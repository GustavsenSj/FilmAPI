using FilmAPI.Data;
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

    public Task<Data.Models.Movie> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
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

    public Task<ICollection<Character>> GetCharactersForMovieAsync(int movieId)
    {
        throw new NotImplementedException();
    }

    public Task AddFranchiseToMovieAsync(int movieId, int franchiseId)
    {
        throw new NotImplementedException();
    }
}
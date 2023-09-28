using FilmAPI.Data;
using FilmAPI.Data.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace FilmAPI.Services.Franchise;

/// <summary>
/// Service for Franchise
/// </summary>
public class FranchiseService : IFranchiseService
{
    private readonly FilmDbContext _context;

    /// <summary>
    /// Constructor for FranchiseService
    /// </summary>
    /// <param name="context"></param>
    public FranchiseService(FilmDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Data.Models.Franchise>> GetAllAsync()
    {
        return await _context.Franchises.Include(f => f.Movies).ToListAsync();
    }

    /// <inheritdoc />
    public async Task<Data.Models.Franchise> GetByIdAsync(int id)
    {
        if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));
        Data.Models.Franchise franchise =
            (await _context.Franchises.Where(f => f.Id == id).Include(f => f.Movies).FirstOrDefaultAsync() ?? null) ??
            throw new EntityNotFoundException(id);
        return franchise;
    }

    /// <inheritdoc />
    public async Task<Data.Models.Franchise> AddAsync(Data.Models.Franchise obj)
    {
        await _context.Franchises.AddAsync(obj);
        await _context.SaveChangesAsync();
        return obj;
    }

    /// <inheritdoc />
    public async Task<Data.Models.Franchise> UpdateAsync(Data.Models.Franchise obj)
    {
        if (!await FranchiseExistsAsync(obj.Id))
            throw new EntityNotFoundException(obj.Id);
        obj.Movies.Clear();
        _context.Entry(obj).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return obj;
    }


    /// <inheritdoc />
    public async Task DeleteAsync(int id)
    {
        if (!await FranchiseExistsAsync(id))
            throw new EntityNotFoundException(id);
        var franchise = await _context.Franchises.FindAsync(id);
        if (franchise != null)
        {
            franchise.Movies.Clear();
            await RemoveFranchiseFromMovies(id);
            _context.Franchises.Remove(franchise);
        }

        await _context.SaveChangesAsync();
    }


    /// <inheritdoc />
    public async Task<ICollection<Data.Models.Movie>> GetMoviesInFranchiseAsync(int id)
    {
        if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));
        if (!await FranchiseExistsAsync(id))
            throw new EntityNotFoundException(id);

        var movies = await _context.Movies.Where(m => m.Franchise != null && m.Franchise.Id == id)
            .ToListAsync();
        if (movies == null)
        {
            throw new EntityNotFoundException(id);
        }

        return movies;
    }


    /// <inheritdoc />
    public async Task UpdateMoviesInFranchiseAsync(int id, int[] movieIds)
    {
        if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));
        if (!await FranchiseExistsAsync(id))
            throw new EntityNotFoundException(id);

        Data.Models.Franchise franchise =
            await _context.Franchises.FindAsync(id) ?? throw new EntityNotFoundException(id);

        List<Data.Models.Movie> movies = new List<Data.Models.Movie>();

        foreach (int movieId in movieIds)
        {
            if (!await MovieExistsAsync(movieId))
                throw new EntityNotFoundException(movieId);
            movies.Add((await _context.Movies.FindAsync(movieId))!);
        }

        franchise.Movies = movies;
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Data.Models.Character>> GetCharactersInFranchiseAsync(int id)
    {
        if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));
        if (!await FranchiseExistsAsync(id))
            throw new EntityNotFoundException(id);
        List<Data.Models.Character> characterList = new List<Data.Models.Character>();

        var franchises =
            await _context.Franchises.Include(f => f.Movies).ThenInclude(m => m.Characters)
                .SingleAsync(f => id == f.Id);
        foreach (var movie in franchises.Movies)
        {
            foreach (var character in movie.Characters)
            {
                if (!characterList.Contains(character))
                    characterList.Add(character);
            }
        }


        return characterList;
    }

    private async Task<bool> MovieExistsAsync(int movieId)
    {
        return await _context.Movies.AnyAsync(m => m.Id == movieId);
    }

    private async Task<bool> FranchiseExistsAsync(int tId)
    {
        return await _context.Franchises.AnyAsync(f => f.Id == tId);
    }

    private async Task RemoveFranchiseFromMovies(int id)
    {
        var movies = await _context.Movies.Where(m => m.Franchise != null && m.Franchise.Id == id).ToListAsync();
        foreach (var movie in movies)
        {
            movie.Franchise = null;
        }
    }
}
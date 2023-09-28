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
        return await _context.Franchises.ToListAsync();
    }

    /// <inheritdoc />
    public async Task<Data.Models.Franchise> GetByIdAsync(int id)
    {
        if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));
        Data.Models.Franchise franchise =
            (await _context.Franchises.Where(f => f.Id == id).FirstOrDefaultAsync() ?? null) ??
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
        if(!await FranchiseExistsAsync(obj.Id))
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

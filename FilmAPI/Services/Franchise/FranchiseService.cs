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
    public Task<Data.Models.Franchise> UpdateAsync(Data.Models.Franchise t)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
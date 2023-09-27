using FilmAPI.Data;
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
    public Task<Data.Models.Franchise> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<Data.Models.Franchise> AddAsync(Data.Models.Franchise t)
    {
        throw new NotImplementedException();
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
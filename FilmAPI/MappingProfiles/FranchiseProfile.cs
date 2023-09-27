using FilmAPI.Data.Dtos.Franchises;
using FilmAPI.Data.Models;
using AutoMapper;

namespace FilmAPI.MappingProfiles;

/// <summary>
/// A mapping profile for the Franchise entity.
/// </summary>
public class FranchiseProfile : Profile
{
    /// <summary>
    /// Creates a mapping profile for the Franchise entity.
    /// </summary>
    public FranchiseProfile()
    {
        CreateMap<Franchise, FranchiseGetDto>();
    }
}
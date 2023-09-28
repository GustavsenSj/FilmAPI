using FilmAPI.Data.Dtos.Franchises;
using FilmAPI.Data.Models;
using AutoMapper;
using FilmAPI.Data.DTOs.Movies;

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
        CreateMap<Franchise, FranchiseGetDto>().ForMember(fdto => fdto.Movies, options => options.MapFrom(franchise => franchise.Movies.Select(movie => new MovieInCharacterDto {Title = movie.Title}).ToList())); 
        CreateMap<FranchisePostDto, Franchise>();
        CreateMap<FranchisePutDto, Franchise>();
    }
}
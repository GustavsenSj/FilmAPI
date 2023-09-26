using AutoMapper;
using FilmAPI.Data.DTOs.Movies;
using FilmAPI.Data.Models;

namespace FilmAPI.MappingProfiles;

/// <summary>
/// A mapping profile for the Movie entity.
/// </summary>
public class MovieProfile : Profile
{
    /// <summary>
    /// Creates a mapping profile for the Movie entity.
    /// </summary>
    public MovieProfile()
    {
        // mov <-> movDto
        CreateMap<Movie, MoviePostDto>().ReverseMap();
        CreateMap<Movie, MoviePutDto>().ReverseMap();
    }
}
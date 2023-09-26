using AutoMapper;
using FilmAPI.Data.DTOs.Movies;
using FilmAPI.Data.Models;

namespace FilmAPI.MappingProfiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        // mov <-> movDto
        CreateMap<Movie, MoviePostDTO>().ReverseMap();
        
    }
}
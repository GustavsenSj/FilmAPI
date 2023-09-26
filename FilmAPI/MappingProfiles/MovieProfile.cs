using AutoMapper;
using FilmAPI.Data.DTOs;
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

         CreateMap<Movie, MovieGetDto>()
        .ForMember(
            mdto => mdto.Characters,
            options => options.MapFrom(
                movie => movie.Characters.Select(character => new CharacterNameInMovieDto
                {
                    FullName = character.FullName,
                    Alias = character.Alias
                }).ToList()
            )
        );

    }
}
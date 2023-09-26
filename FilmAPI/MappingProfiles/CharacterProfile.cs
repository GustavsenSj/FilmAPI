using AutoMapper;
using FilmAPI.Data.Dtos.Characters;
using FilmAPI.Data.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace FilmAPI.MappingProfiles
{
    /// <summary>
    /// The CharacterProfile class is a mapping profile class that maps between the Character and different CharacterDto classes.
    /// </summary>
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            // chr <-> chrDto
            CreateMap<Character, CharacterDto>();
            CreateMap<CharacterDto, Character>();
            CreateMap<CharacterNameInMovieDto, CharacterDto>();
            CreateMap<Character, CharacterInMovieDto>();
        }
    }
}
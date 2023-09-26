using AutoMapper;
using FilmAPI.Data.DTOs;
using FilmAPI.Data.Models;

namespace FilmAPI.MappingProfiles
{
    public class CharacterProfile: Profile
    {
        public CharacterProfile() 
        { 
            // chr <-> chrDto
            CreateMap<Character, CharacterDto>();
            CreateMap<CharacterDto, Character>();
            CreateMap<CharacterInMovieDto, CharacterDto>();
        }
    }
}

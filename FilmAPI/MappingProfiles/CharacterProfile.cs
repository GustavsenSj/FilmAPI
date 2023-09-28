﻿using AutoMapper;
using FilmAPI.Data.Dtos.Characters;
using FilmAPI.Data.DTOs.Movies;
using FilmAPI.Data.Models;


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
            CreateMap<Character, CharacterDto>()
                .ForMember(cdto => cdto.Movies,
                    options => options.MapFrom(
                        character => character.Movies.Select(movie => new MovieInCharacterDto
                        {
                            Title = movie.Title,
                        }).ToList()
                    )
                )
                ;
            CreateMap<CharacterDto, Character>();
            CreateMap<CharacterNameInMovieDto, CharacterDto>();
            CreateMap<Character, CharacterInMovieDto>();
            CreateMap<Character, CharacterAddDto>().ReverseMap();
            CreateMap<Character, CharacterUpdateDto>().ReverseMap();
            CreateMap<Character, CharacterInFranchiseDto>();
            
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using FilmAPI.Data.Models;
using FilmAPI.Services.Character;
using AutoMapper;
using FilmAPI.Data.Dtos.Characters;
using FilmAPI.Data.DTOs.Movies;
using FilmAPI.Data.Exceptions;

namespace FilmAPI.Controllers;
/// <summary>
///  Controller for the Character entity
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CharactersController : ControllerBase
{
    //private readonly FilmDbContext _context;
    private readonly ICharacterService _characterService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor for the CharacterController
    /// </summary>
    /// <param name="characterService"></param>
    /// <param name="mapper"></param>
    public CharactersController(ICharacterService characterService, IMapper mapper)
    {
        _characterService = characterService;
        _mapper = mapper;
    }

    /// <summary>
    /// Get all characters in the database
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CharacterDto>>> GetCharacters()
    {
        // prob add try catch here
        // not possible assigning type to Models.Character & DTOs.CharacterDto

        // Get all chrs from service
        var characters = await _characterService.GetAllAsync();

        //map chrs->chrDto objs
        var characterDtos = _mapper.Map<IEnumerable<CharacterDto>>(characters);

        // return mappd chrsDtos as resp.
        return Ok(characterDtos);
    }

    /// <summary>
    /// Get a character by its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<CharacterDto>> GetCharacter(int id)
    {
        try
        {
            var character = await _characterService.GetByIdAsync(id);
            var characterDto = _mapper.Map<CharacterDto>(character);
            return Ok(characterDto);
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }


        /// <summary>
        /// Update a character in the database 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="characterDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCharacter(int id,CharacterUpdateDto characterDto)
        {
            if (id != characterDto.Id)
            {
                return BadRequest();
            }

        try
        {
            // chrDto -> chr entity
            var character = _mapper.Map<Character>(characterDto);
            //update chr in db
            await _characterService.UpdateAsync(character);
            return Ok(character);
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

        /// <summary>
        /// Add a character to the database
        /// </summary>
        /// <param name="characterDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CharacterAddDto>> AddCharacter(CharacterAddDto characterDto)
        {
            // chrDto -> chr entity
            var character = _mapper.Map<Character>(characterDto);
            try
            {
                // post it to db
                var addedCharacter = await _characterService.AddAsync(character);
                int assignedId = addedCharacter.Id;
                // map back to dto
                var addedCharacterDto = _mapper.Map<CharacterAddDto>(addedCharacter);
                return CreatedAtAction(nameof(addedCharacterDto),
                    new { id = assignedId },
                    addedCharacterDto);
            }
            catch (EntityAlreadyExistsException ex)
            {
                // from stackoverflow, status code 409
                // see https://stackoverflow.com/questions/3825990/http-response-code-for-post-when-resource-already-exists
                return Conflict(ex.Message);
            }
        }


        /// <summary>
        /// Delete a character from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            // catch the entitynotfound excpetion from the service layer
            try
            {
                await _characterService.DeleteAsync(id);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

    /// <summary>
    /// Get all Characters in a movie 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}/movies")]
    public async Task<ActionResult<IEnumerable<MoviesByCharacterDto>>> GetCharacterInMovies(int id)
    {
        try
        {
            var movies = await _characterService.GetCharacterInMoviesAsync(id);
            // map to dtos
            var moviesDto = _mapper.Map<IEnumerable<MoviesByCharacterDto>>(movies);
            return Ok(moviesDto);
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
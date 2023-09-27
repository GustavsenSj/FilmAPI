using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilmAPI.Data;
using FilmAPI.Data.Models;
using FilmAPI.Services.Character;
using AutoMapper;
using FilmAPI.Data.DTOs;
using System.Data;
using FilmAPI.Data.Exceptions;
using FilmAPI.Data.DTOs.Movies;
using FilmAPI.Data.DTOs.Characters;
using FilmAPI.Data.Dtos.Characters;

namespace FilmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        //private readonly FilmDbContext _context;
        private readonly ICharacterService _characterService;
        private readonly IMapper _mapper;

        public CharactersController(ICharacterService characterService, IMapper mapper)
        {
            _characterService = characterService;
            _mapper = mapper;
        }

        /**************************************************************************************/
        // GET: api/Characters
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

        /**************************************************************************************/
        // GET: api/Characters/5
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

        /**************************************************************************************/
        // PUT: api/Characters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCharacter(int id, CharacterUpdateDto characterDto)
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

        /**************************************************************************************/
        // POST: api/Characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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
                return CreatedAtAction(nameof(GetCharacter), 
                    new { id = assignedId}, 
                    addedCharacterDto);
            }
            catch (EntityAlreadyExistsException ex)
            {
                // from stackoverflow, status code 409
                // see https://stackoverflow.com/questions/3825990/http-response-code-for-post-when-resource-already-exists
                return Conflict(ex.Message); 
            }
        }

        /**************************************************************************************/
        // DELETE: api/Characters/5
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

        /**************************************************************************************/
        [HttpGet("{id}/movies")]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetCharacterInMovies(int id)
        {
            try
            {
                var movies = await _characterService.GetCharacterInMoviesAsync(id);
                // map to dtos
                var moviesDto = _mapper.Map<IEnumerable<MovieDto>>(movies);
                return Ok(moviesDto);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}

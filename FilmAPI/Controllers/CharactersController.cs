using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilmAPI.Data;
using FilmAPI.Data.Models;
using FilmAPI.Services.Character;
using AutoMapper;
using FilmAPI.Data.DTOs;
using System.Data;

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

        // GET: api/Characters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDto>> GetCharacter(int id)
        {
            // if not found (null character)
            if (await _characterService.GetByIdAsync(id) == null)
            {
                return NotFound(); //404
            }

            // map chr->chrDto
            var character = await _characterService.GetByIdAsync(id);

            // mapped chrDto as resp.
            var characterDto = _mapper.Map<CharacterDto>(character);
            return Ok(characterDto);
        }

        // PUT: api/Characters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCharacter(int id, CharacterDto characterDto)
        {
            // chrDto -> chr entity
            var character = _mapper.Map<Character>(characterDto);
            //update chr in db
            await _characterService.UpdateAsync(character);
            return Ok(character);
        }

        // POST: api/Characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CharacterDto>> AddCharacter(Character characterDto)
        {
            // chrDto -> chr entity
            var character = _mapper.Map<Character>(characterDto);
            // post it to db
            var addedCharacter = await _characterService.AddAsync(character);
            // map back to dto
            var addedCharacterDto = _mapper.Map<CharacterDto>(addedCharacter);
            return CreatedAtAction(nameof(GetCharacter), new { id = addedCharacterDto.Id }, addedCharacterDto);
        }

        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            if (await _characterService.GetByIdAsync(id) != null)
            {
                await _characterService.DeleteAsync(id);
                return NoContent();
            }
            return NotFound();
        }
    }
}

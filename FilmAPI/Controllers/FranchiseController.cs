using AutoMapper;
using FilmAPI.Data.Dtos.Characters;
using FilmAPI.Data.Dtos.Franchises;
using FilmAPI.Data.DTOs.Movies;
using FilmAPI.Data.Exceptions;
using FilmAPI.Data.Models;
using FilmAPI.Services.Franchise;
using Microsoft.AspNetCore.Mvc;

namespace FilmAPI.Controllers;

/// <summary>
/// Controller for Franchise
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class FranchiseController : ControllerBase
{
    private readonly IFranchiseService _service;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor for FranchiseController
    /// </summary>
    /// <param name="service"></param>
    /// <param name="mapper"></param>
    public FranchiseController(IFranchiseService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    /// <summary>
    /// Get all franchises in the database
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FranchiseGetDto>>> GetFranchises()
    {
        return Ok(_mapper.Map<IEnumerable<FranchiseGetDto>>(
            await _service.GetAllAsync())
        );
    }

    /// <summary>
    /// Get a franchise by its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<FranchiseGetDto>> GetFranchiseById(int id)
    {
        return Ok(_mapper.Map<FranchiseGetDto>(await _service.GetByIdAsync(id)));
    }

    /// <summary>
    /// Post a new franchise to the database
    /// </summary>
    /// <param name="franchise">The Franchise to be added</param>
    /// <returns>The created franchise</returns>
    [HttpPost]
    public async Task<ActionResult<FranchisePostDto>> PostFranchise(FranchisePostDto franchise)
    {
        var newFranchise = await _service.AddAsync(_mapper.Map<Franchise>(franchise));
        return CreatedAtAction("GetFranchiseById", new { id = newFranchise.Id }, newFranchise);
    }

    /// <summary>
    /// Update a franchise in the database
    /// </summary>
    /// <param name="id">The id of the franchise to update</param>
    /// <param name="franchise"> The franchise object with updated information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<FranchisePutDto>> PutFranchise(int id, FranchisePutDto franchise)
    {
        if (id != franchise.Id)
        {
            return BadRequest();
        }

        try
        {
            var newFranchise = await _service.UpdateAsync(_mapper.Map<Franchise>(franchise));
            return Ok(newFranchise);
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// Delete a franchise from the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFranchise(int id)
    {
        try
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// Get all the movies in a franchise
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}/movies")]
    public async Task<ActionResult<IEnumerable<MovieInFranchiseDto>>> GetMoviesByFranchiseId(int id)
    {
        try
        {
            var movies = await _service.GetMoviesInFranchiseAsync(id);
            return Ok(_mapper.Map<IEnumerable<MovieInFranchiseDto>>(movies));
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPut("{id}/movies")]
    public async Task<IActionResult> updateMovies(int id, [FromBody] int[] movieIds)
    {
        try
        {
            await _service.UpdateMoviesInFranchiseAsync(id, movieIds);
            return Ok();
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    /// <summary>
    /// Get all the characters in a franchise
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}/characters")]
    public async Task<ActionResult<IEnumerable<CharacterInFranchiseDto>>> GetCharactersByFranchiseId(int id)
    {
        try
        {
            var characters = await _service.GetCharactersInFranchiseAsync(id);
            return Ok(_mapper.Map<IEnumerable<CharacterInFranchiseDto>>(characters));
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}
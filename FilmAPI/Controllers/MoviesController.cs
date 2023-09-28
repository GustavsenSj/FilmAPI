using AutoMapper;
using FilmAPI.Data.Dtos.Characters;
using FilmAPI.Data.DTOs.Movies;
using FilmAPI.Data.Exceptions;
using Microsoft.AspNetCore.Mvc;
using FilmAPI.Data.Models;
using FilmAPI.Services.Movie;

namespace FilmAPI.Controllers;

/// <summary>
/// Controller for Movie
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly IMovieService _service;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor for MovieController
    /// </summary>
    /// <param name="service"></param>
    /// <param name="mapper"></param>
    public MovieController(IMovieService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    /// <summary>
    /// Get all movies in the database
    /// </summary>
    /// <returns> </returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieGetDto>>> GetMovies()
    {
        return Ok(_mapper.Map<IEnumerable<MovieGetDto>>(
            await _service.GetAllAsync())
        );
    }

    /// <summary>
    /// Get a movie by its id
    /// </summary>
    /// <param name="id"> The id of the movie to get</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<MovieGetDto>> GetMovieById(int id)
    {
        var movie = await _service.GetByIdAsync(id);
        if (movie == null)
        {
            return NotFound();
        }

        var movieDto = _mapper.Map<MovieGetDto>(movie);

        return Ok(movieDto);
    }

    /// <summary>
    /// Create a new movie in the database 
    /// </summary>
    /// <param name="movie">The movie to be added</param>
    /// <returns> The created movie Entity</returns>
    [HttpPost]
    public async Task<ActionResult<MoviePostDto>> PostMovie(MoviePostDto movie)
    {
        // dto->entity
        var movieEntity = _mapper.Map<Movie>(movie);
        try
        {
            // post to db
            var postedMovie = await _service.AddAsync(_mapper.Map<Movie>(movieEntity));
            int assingedId = postedMovie.Id;
            // reverse map back to dot
            var postedMovieDto = _mapper.Map<MoviePostDto>(postedMovie);
            
            return CreatedAtAction(nameof(PostMovie),
                new { id = assingedId },
                postedMovieDto);
        }
        catch (EntityAlreadyExistsException ex)
        {
            return Conflict(ex.Message);
        }
    }

    /// <summary>
    /// Update an existing movie in the database 
    /// </summary>
    /// <param name="id"> The id of the movie you want to update</param>
    /// <param name="movie">the movie entity you want to insert</param>
    /// <returns></returns>
    /// <exception cref="EntityNotFoundException"></exception>
    [HttpPut]
    public async Task<ActionResult<MoviePutDto>> PutMovie(int id, MoviePutDto movie)
    {
        if (id != movie.Id)
            return BadRequest();
        try
        {
            var newMovie = await _service.UpdateAsync(_mapper.Map<Movie>(movie));
            return Ok(newMovie);
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// Delete a movie from the database
    /// </summary>
    /// <param name="id">Id of the movie you want to delete</param>
    /// <returns></returns>
    /// <exception cref="EntityNotFoundException"></exception>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovie(int id)
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
    /// Add a list of characters to a movie 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="characterIds"></param>
    /// <returns></returns>
    /// <exception cref="EntityNotFoundException"></exception>
    [HttpPut("{id}/characters")]
    public async Task<IActionResult> UpdateCharacters(int id, [FromBody] int[] characterIds)
    {
        try
        {
            await _service.UpdateCharacterInMovieAsync(id, characterIds);
            return Ok();
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(e.Message);
        }
        // catch (EntityValidationException e)
        // {
        //     return BadRequest(e.Message);
        // }
    }

    /// <summary>
    /// Get all characters for a movie
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="EntityNotFoundException"></exception>
    [HttpGet("{id}/characters")]
    public async Task<ActionResult<IEnumerable<CharacterInMovieDto>>> GetCharacters(int id)
    {
        try
        {
            return Ok(_mapper.Map<IEnumerable<CharacterInMovieDto>>(
                await _service.GetCharactersForMovieAsync(id))
            );
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    
    [HttpPut("{id}/franchise")]
    public async Task<IActionResult> UpdateFranchise(int id, [FromBody] int franchiseId)
    {
        try
        {
            await _service.AddFranchiseToMovieAsync(id, franchiseId);
            return Ok();
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}
using System.Net.Mime;
using AutoMapper;
using FilmAPI.Data.DTOs;
using FilmAPI.Data.DTOs.Movies;
using FilmAPI.Data.Exceptions;
using Microsoft.AspNetCore.Mvc;
using FilmAPI.Data.Models;
using FilmAPI.Services.Movie;
using Microsoft.AspNetCore.Mvc.Formatters;

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
    public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
    {
        return Ok(await _service.GetAllAsync());
        //TODO: create exception to catch not found
    }
    
    /// <summary>
    /// Get a movie by its id
    /// </summary>
    /// <param name="id"> The id of the movie to get</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Movie>> GetMovieById(int id)
    {
        var movie = await _service.GetByIdAsync(id);
        return Ok(movie);
    }

    /// <summary>
    /// Create a new movie in the database 
    /// </summary>
    /// <param name="movie">The movie to be added</param>
    /// <returns> The created movie Entity</returns>
    [HttpPost]
    public async Task<ActionResult<MoviePostDto>> PostMovie(MoviePostDto movie)
    {
        var newMovie = await _service.AddAsync(_mapper.Map<Movie>(movie));
        return CreatedAtAction("GetMovieById", new {id = newMovie.Id}, newMovie);
    }
    [HttpPut]
    public async Task<ActionResult<MoviePutDto>> PutMovie(int id, MoviePutDto movie)
    {
        if(id != movie.Id)
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
}


using System.Net.Mime;
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

    public MovieController(IMovieService service)
    {
        _service = service;
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
}
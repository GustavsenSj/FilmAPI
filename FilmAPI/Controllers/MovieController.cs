using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using FilmAPI.Data.Models;
using FilmAPI.Services.Movie;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace FilmAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[ApiConventionType(typeof(DefaultApiConventions))]
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
    
}
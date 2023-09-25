using Microsoft.AspNetCore.Mvc;
using FilmAPI.Data.Models;
using FilmAPI.Services.Movie;
namespace FilmAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMovieService _service;

    public MoviesController(IMovieService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
    {
        return Ok(await _service.GetAllAsync());
    }
    
}
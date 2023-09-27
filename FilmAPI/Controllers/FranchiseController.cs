using AutoMapper;
using FilmAPI.Data.Dtos.Franchises;
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
    public async Task<ActionResult<IEnumerable<Franchise>>> GetFranchises()
    {
        return Ok(_mapper.Map<IEnumerable<FranchiseGetDto>>(
            await _service.GetAllAsync())
        );
    }
    
}
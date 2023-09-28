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
        var franchise = await _service.GetByIdAsync(id);
        if (franchise == null)
        {
            return NotFound();
        }
        var franchiseDto = _mapper.Map<FranchiseGetDto>(franchise);
        return Ok(franchiseDto);
    }

    /// <summary>
    /// Post a new franchise to the database
    /// </summary>
    /// <param name="franchise"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<FranchisePostDto>> PostFranchise(FranchisePostDto franchise)
    {
        var newFranchise = await _service.AddAsync( _mapper.Map<Franchise>(franchise));
        return CreatedAtAction("GetFranchiseById", new {id = newFranchise.Id}, newFranchise);
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PrimeraAPI.Models;
using PrimeraAPI.Response;
using PrimeraAPI.Data;


namespace PrimeraAPI.Controllers;

[ApiController, Route("[Controller]")]
public class BandsController : ControllerBase
{
    private readonly MusicDbContext _context;

    public BandsController(MusicDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Band>>> Get()
    {
        var bands = await _context.Bands.Where(x => x.Active).ToListAsync();

        return Ok(bands);
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<ApiResponse<Band>>> Get(long id) 
    {
        var band = await _context.Bands
            .FirstOrDefaultAsync(x => x.Id == id);

        if (band == null) return NotFound(ApiResponse<Band>.Failure(404, "Banda no encontrada"));//patron result

        return Ok(ApiResponse<Band>.Success(band));
    }


    /*public async Task<ActionResult<ApiResponse<Band>>> Create(Band band)
    {
      
    }
    */
}


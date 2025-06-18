using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PrimeraAPI.Models;
using PrimeraAPI.Response;
using PrimeraAPI.Data;


namespace PrimeraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BandsController : ControllerBase
    {
        private readonly MusicDbContext _context;

        public BandsController(MusicDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<Band>>>> GetBands()
        {
            var bands = await _context.Bands.ToListAsync();
            return new ApiResponse<IEnumerable<Band>>(true, "Band list retrieved", bands);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<Band>>> GetBand(int id)
        {
            var band = await _context.Bands.FindAsync(id);
            if (band == null)
                return NotFound(new ApiResponse<Band>(false, "Band not found"));

            return new ApiResponse<Band>(true, "Band found", band);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<Band>>> CreateBand(Band band)
        {
            _context.Bands.Add(band);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBand), new { id = band.Id }, new ApiResponse<Band>(true, "Band created", band));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBand(int id, Band updatedBand)
        {
            if (id != updatedBand.Id)
                return BadRequest(new ApiResponse<Band>(false, "ID mismatch"));

            _context.Entry(updatedBand).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new ApiResponse<Band>(true, "Band updated", updatedBand));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Bands.Any(b => b.Id == id))
                    return NotFound(new ApiResponse<Band>(false, "Band not found"));

                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBand(int id)
        {
            var band = await _context.Bands.FindAsync(id);
            if (band == null)
                return NotFound(new ApiResponse<Band>(false, "Band not found"));

            _context.Bands.Remove(band);
            await _context.SaveChangesAsync();
            return Ok(new ApiResponse<Band>(true, "Band deleted"));
        }
    }
}

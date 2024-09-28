using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateAPI.Data;
using RealEstateAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class ResidentController : ControllerBase
{
    private readonly AppDbContext _context;

    public ResidentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Resident>>> GetResidents()
    {
        return await _context.Residents.Include(r => r.Apartment).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Resident>> PostResident(Resident resident)
    {
        _context.Residents.Add(resident);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetResident", new { id = resident.Id }, resident);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutResident(int id, Resident resident)
    {
        if (id != resident.Id)
        {
            return BadRequest();
        }

        _context.Entry(resident).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteResident(int id)
    {
        var resident = await _context.Residents.FindAsync(id);
        if (resident == null)
        {
            return NotFound();
        }

        _context.Residents.Remove(resident);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}

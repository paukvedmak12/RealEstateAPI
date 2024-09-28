using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateAPI.Data;
using RealEstateAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class ApartmentController : ControllerBase
{
    private readonly AppDbContext _context;

    public ApartmentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Apartment>>> GetApartments()
    {
        return await _context.Apartments.Include(a => a.House).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Apartment>> PostApartment(Apartment apartment)
    {
        _context.Apartments.Add(apartment);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetApartment", new { id = apartment.Id }, apartment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutApartment(int id, Apartment apartment)
    {
        if (id != apartment.Id)
        {
            return BadRequest();
        }

        _context.Entry(apartment).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteApartment(int id)
    {
        var apartment = await _context.Apartments.FindAsync(id);
        if (apartment == null)
        {
            return NotFound();
        }

        _context.Apartments.Remove(apartment);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}

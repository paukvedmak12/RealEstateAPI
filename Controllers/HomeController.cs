using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateAPI.Data;
using RealEstateAPI.Models;

namespace RealEstateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HouseController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/house
        [HttpGet]
        public async Task<ActionResult<IEnumerable<House>>> GetHouses()
        {
            return await _context.Houses.ToListAsync();
        }

        // POST: api/house
        [HttpPost]
        public async Task<ActionResult<House>> CreateHouse(House house)
        {
            _context.Houses.Add(house);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetHouses), new { id = house.Id }, house);
        }

        // PUT: api/house/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHouse(int id, House house)
        {
            if (id != house.Id)
            {
                return BadRequest();
            }

            _context.Entry(house).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/house/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHouse(int id)
        {
            var house = await _context.Houses.FindAsync(id);
            if (house == null)
            {
                return NotFound();
            }

            _context.Houses.Remove(house);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

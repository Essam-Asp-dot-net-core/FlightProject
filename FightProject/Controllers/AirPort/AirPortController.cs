using Flight.Core.Entities;
using Flight.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flight.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirPortController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AirPortController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/AirPort
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirPort>>> GetAirPorts()
        {
            return await _context.AirPorts.ToListAsync();
        }

        // GET: api/AirPort/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AirPort>> GetAirPort(int id)
        {
            var airPort = await _context.AirPorts.FindAsync(id);

            if (airPort == null)
            {
                return NotFound();
            }

            return airPort;
        }

        // POST: api/AirPort
        [HttpPost]
        public async Task<ActionResult<AirPort>> PostAirPort(AirPort airPort)
        {
            _context.AirPorts.Add(airPort);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAirPort", new { id = airPort.Id }, airPort);
        }

        // PUT: api/AirPort/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirPort(int id, AirPort airPort)
        {
            if (id != airPort.Id)
            {
                return BadRequest();
            }

            _context.Entry(airPort).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirPortExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/AirPort/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirPort(int id)
        {
            var airPort = await _context.AirPorts.FindAsync(id);
            if (airPort == null)
            {
                return NotFound();
            }

            _context.AirPorts.Remove(airPort);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AirPortExists(int id)
        {
            return _context.AirPorts.Any(e => e.Id == id);
        }
    }
}

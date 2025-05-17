using AutoMapper;
using Flight.Core.Entities;
using Flight.Repository;
using FlightProject.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public FlightsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightDto>>> GetAllFlights()
        {
            var flights = await _context.Flights
                .Include(f => f.DepartureAirPort)
                .Include(f => f.ArrivalAirPort)
                .Include(f => f.Airplane)
                .Where(f => !f.IsDeleted)
                .ToListAsync();

            var result = _mapper.Map<List<FlightDto>>(flights);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FlightDto>> GetFlightById(int id)
        {
            var flight = await _context.Flights
                .Include(f => f.DepartureAirPort)
                .Include(f => f.ArrivalAirPort)
                .Include(f => f.Airplane)
                .Include(f => f.Tickets)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (flight == null)
                return NotFound();

            var dto = _mapper.Map<FlightDto>(flight);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<FlightDto>> AddFlight([FromBody] FlightDto dto)
        {
            var flight = _mapper.Map<Flight.Core.Entities.Flight>(dto);

            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<FlightDto>(flight);
            return CreatedAtAction(nameof(GetFlightById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlight(int id, [FromBody] FlightDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var existingFlight = await _context.Flights.FindAsync(id);
            if (existingFlight == null)
                return NotFound();

            _mapper.Map(dto, existingFlight);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight == null)
                return NotFound();

            flight.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

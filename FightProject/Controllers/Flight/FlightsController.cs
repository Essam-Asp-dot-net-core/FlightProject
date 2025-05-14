using Flight.Core.Entities;
using Flight.Repository;
using FlightProject.DTOs;
using FlightProject.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FlightsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightDto>>> GetAllFlights()
        {
            var flights = await _context.Flights
                .Include(f => f.DepartureAirPort)
                .Include(f => f.ArrivalAirPort)
                .ToListAsync();

            var result = flights.Select(FlightMapper.ToDto).ToList();
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

            return Ok(FlightMapper.ToDto(flight));
        }

        [HttpPost]
        public async Task<ActionResult<FlightDto>> AddFlight([FromBody] FlightDto dto)
        {
            var flight = FlightMapper.ToEntity(dto);
            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();
            dto.Id = flight.Id;
            return CreatedAtAction(nameof(GetFlightById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlight(int id, [FromBody] FlightDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var existing = await _context.Flights.FindAsync(id);
            if (existing == null)
                return NotFound();

            existing.FlightNumber = dto.FlightNumber;
            existing.DepartureAirPortId = dto.FromAirportId;
            existing.ArrivalAirPortId = dto.ToAirportId;
            existing.DepartureTime = dto.DepartureTime;
            existing.ArrivalTime = dto.ArrivalTime;
            existing.AirplaneId = dto.AirplaneId;
            existing.Price = dto.Price;
            existing.Status = dto.Status;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight == null)
                return NotFound();

            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

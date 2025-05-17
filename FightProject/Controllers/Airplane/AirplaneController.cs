using AutoMapper;
using Flight.Core.Entities;
using Flight.Repository;
using FlightProject.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flight.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplaneController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AirplaneController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirplaneDto>>> GetAirplanes()
        {
            var airplanes = await _context.Airplanes
                .Where(a => !a.IsDeleted)
                .ToListAsync();

            var result = _mapper.Map<List<AirplaneDto>>(airplanes);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AirplaneDto>> GetAirplane(int id)
        {
            var airplane = await _context.Airplanes.FindAsync(id);

            if (airplane == null || airplane.IsDeleted)
                return NotFound();

            var result = _mapper.Map<AirplaneDto>(airplane);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<AirplaneDto>> PostAirplane(AirplaneDto dto)
        {
            var entity = _mapper.Map<Airplane>(dto);
            _context.Airplanes.Add(entity);
            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            return CreatedAtAction(nameof(GetAirplane), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirplane(int id, AirplaneDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var entity = await _context.Airplanes.FindAsync(id);
            if (entity == null || entity.IsDeleted)
                return NotFound();

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirplane(int id)
        {
            var entity = await _context.Airplanes.FindAsync(id);
            if (entity == null || entity.IsDeleted)
                return NotFound();

            entity.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
